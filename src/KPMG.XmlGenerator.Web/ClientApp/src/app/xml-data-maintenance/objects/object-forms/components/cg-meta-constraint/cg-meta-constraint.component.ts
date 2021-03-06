import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import {
  IcgMetaObjectOutput,
  IConstraintToAreaOutput,
  IConstraint,
  IcgMetaTechnicalSetting,
} from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import { take } from 'rxjs/operators';
import { LocalStorageService } from '@app/shared/services/local-storage.service';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { CompareConstraints, COMPARE_CONSTRAINTS } from '@app/common/form-validators/compare-constraints.validator';
import * as _ from 'lodash';
import { CreateObjectSteps } from '../../../objects-shared-module/resources';

@Component({
  selector: 'app-cg-meta-constraint',
  templateUrl: './cg-meta-constraint.component.html',
  styleUrls: ['./cg-meta-constraint.component.scss'],
})
export class CgMetaConstraintComponent implements OnInit {
  constructor(
    private readonly fb: FormBuilder,
    private readonly createObjectService: CreateObjectService,
    private readonly router: Router,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    @Inject(COMPARE_CONSTRAINTS)
    protected readonly compareConstraints: CompareConstraints,
    private readonly route: ActivatedRoute,
    protected readonly localStorageService: LocalStorageService,
    private readonly ngZone: NgZone
  ) {}

  private _canILeave = false;
  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_COLUMN_MAPPING}`;

  public cgMetaObjectDTO: IcgMetaObjectOutput;
  public getTechnicalSettingsData: IcgMetaTechnicalSetting;
  public createForm: FormGroup;
  public constraints: FormArray;
  public constraintFields;
  public constraintOptions;
  public constraintValues;
  public constraintAreas;
  public constraintInSQL = [
    {
      name: 'Yes',
      value: true,
    },
    {
      name: 'No',
      value: false,
    },
  ];
  public isConstraintDuplicate: boolean;

  public constraint_errors: IErrorSet = {
    constraintField: [{ type: 'required', message: 'Mandatory field' }],
    constraintOption: [{ type: 'required', message: 'Mandatory field' }],
    constraintValue: [{ type: 'required', message: 'Mandatory field' }],
    area: [{ type: 'required', message: 'Mandatory field' }],
    priority: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'min', message: 'Enter number between 1 and 100' },
      { type: 'max', message: 'Enter number between 1 and 100' },
    ],
  };

  ngOnInit() {
    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');
    this.getTechnicalSettingsData = this.createObjectService.getData('cgMetaObjectTechnicalSettings');

    this.route.data.pipe(take(1)).subscribe(data => {
      this.constraintOptions = data.constraintOption;
      this.constraintValues = data.constraintValue;
    });
    this.constraintFields = this.getTechnicalSettingsData.dd03Fields;

    let selectedAreas = [...this.createObjectService.getData('mappedAreas').mappedAreas];
    let genericArea = selectedAreas.find(a => a.areaName.toUpperCase() === 'GENERIC');
    if (!genericArea) {
      genericArea = { id: -1, areaName: 'GENERIC', versionId: this.localStorageService.getVersion().id };
    } else {
      selectedAreas = selectedAreas.filter(a => a.areaName.toUpperCase() !== 'GENERIC');
    }
    this.constraintAreas = [genericArea, ...selectedAreas];

    const stepData = this.createObjectService.getData('cgMetaConstraintsArea');

    // build The FormGroup
    this.constraints = this.fb.array([]);
    if (!!stepData) {
      stepData.constraints.forEach(c => this.constraints.push(this.buildConstraintFormGroup(c)));
    }
    this.createForm = this.fb.group({
      constraints: this.constraints,
    });
    this.constraints.setValidators(this.compareConstraints);
  }

  private buildConstraintFormGroup(constraint: IConstraint): FormGroup {
    let extractionLogicName: string = constraint.extractionLogicName;
    if (
      !extractionLogicName &&
      !!this.getTechnicalSettingsData &&
      !!this.getTechnicalSettingsData.cgMetaExtractionLogic
    ) {
      extractionLogicName = this.getTechnicalSettingsData.cgMetaExtractionLogic.cgMetaExtractionLogicName;
    }
    return this.fb.group({
      constraintField: this.fb.control(constraint.constraintField, [Validators.required]),
      constraintOption: this.fb.control(constraint.constraintOption, [Validators.required]),
      constraintValue: this.fb.control(constraint.constraintValue, [Validators.required]),
      area: this.fb.control(constraint.area, [Validators.required]),
      extractionLogicName: this.fb.control({ value: extractionLogicName, disabled: true }),
      inSQL: this.fb.control(constraint.inSQL),
      priority: this.fb.control(constraint.priority, [Validators.required, Validators.min(1), Validators.max(100)]),
    });
  }

  public addConstaint(): void {
    if (!this.createForm.valid) return;

    this.constraints.push(
      this.buildConstraintFormGroup(<IConstraint>{
        inSQL: true,
        priority: 1,
        area: this.constraintAreas.find(a => a.areaName.toUpperCase() === 'GENERIC'),
      })
    );

    this.ngZone.runOutsideAngular(() =>
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 0)
    );
  }

  public doIHaveErorValue(myValue) {
    if (!this.createForm.get('constraints').errors) return false;

    const theError = this.createForm.get('constraints').errors.diff;
    if (!theError) return false;

    return _.isEqual(myValue, theError.value);
  }

  public destroyMe(i): void {
    this.constraints.removeAt(i);
    this.isConstraintDuplicate = false;

    this.ngZone.runOutsideAngular(() =>
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 0)
    );
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public nextStep(): void {
    this.markAsTouched(this.constraints);
    if (!this.createForm.valid) return;

    const stepData = this.createForm.value;
    this.createObjectService.setData('cgMetaConstraintsArea', stepData, false);

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA}`], { relativeTo: this.route.parent });
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_COLUMN_MAPPING}`], { relativeTo: this.route.parent });
  }
}
