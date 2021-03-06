import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { IArea } from '../../../../../common/interfaces';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';
import { IToggleButtonOption } from '../../../../../common/toggle-button/components';
import { LocalStorageService } from '../../../../../shared/services/local-storage.service';
import { CreateObjectService } from '../../../create-object.service';
import { HardConstraintValidators } from '../../../hard-constraint-validators';
import { IHardCodedConstraint } from '../../../interfaces/create-object-output.interface';
import { ObjectsService } from '../../../objects.service';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '../../../../../common/forms';
import { CreateObjectSteps } from '../../../objects-shared-module/resources';
import { CompareHConstraints, COMPARE_H_CONSTRAINTS } from '@app/common/form-validators/compare-hconstraints.validator';
import * as _ from 'lodash';

@Component({
  selector: 'app-cg-meta-hconstraint-to-area',
  templateUrl: './cg-meta-hconstraint-to-area.component.html',
  styleUrls: ['./cg-meta-hconstraint-to-area.component.scss'],
})
export class CgMetaHconstraintToAreaComponent implements OnInit {
  public _canILeave = false;
  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_CONSTRAINT}`;

  public objectName = '';
  public fgHardConstraints: FormGroup;
  public controlErrors: IErrorSet = {
    hconstraintName: [{ type: 'required', message: 'Mandatory field' }],
    area: [{ type: 'required', message: 'Mandatory field' }],
  };
  public areas: IArea[] = [];
  public isDefaultOptions: IToggleButtonOption[] = [
    {
      name: 'Yes',
      value: true,
    },
    {
      name: 'No',
      value: false,
    },
  ];
  private _objectTableName: string = null;

  public canILeave() {
    return this._canILeave;
  }

  constructor(
    private readonly objectService: ObjectsService,
    private readonly router: Router,
    private readonly route: ActivatedRoute,
    private readonly createObjectService: CreateObjectService,
    private readonly localStorageService: LocalStorageService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly ngZone: NgZone,
    @Inject(COMPARE_H_CONSTRAINTS)
    protected readonly compareHConstraints: CompareHConstraints,
  ) {}

  ngOnInit() {
    const formData = this.createObjectService.getData('hardCodedConstraints');
    const hardConstraints = !!formData ? formData.faHardConstraints : [];
    const objectData = this.createObjectService.getData('cgMetaObjectDTO');
    if (!!objectData) {
      this._objectTableName = objectData.mapCgMetaTableName;
      this.objectName = objectData.cgMetaObjectName;
    }
    let selectedAreas = [...this.createObjectService.getData('mappedAreas').mappedAreas];
    let genericArea = selectedAreas.find(a => a.areaName.toUpperCase() === 'GENERIC');
    if (!genericArea) {
      genericArea = { id: -1, areaName: 'GENERIC', versionId: this.localStorageService.getVersion().id };
    } else {
      selectedAreas = selectedAreas.filter(a => a.areaName.toUpperCase() !== 'GENERIC');
    }
    this.areas = [genericArea, ...selectedAreas];
    this.buildFormArray(hardConstraints);
  }

  private buildFormArray(hardConstraints: IHardCodedConstraint[]) {
    const formArr = new FormArray([]);
    hardConstraints.forEach(hcc => formArr.push(this.buildHardConstraintFormGroup(hcc)));
    formArr.setValidators(this.compareHConstraints);
    this.fgHardConstraints = new FormGroup({ faHardConstraints: formArr }, { updateOn: 'change' });
  }

  private buildHardConstraintFormGroup(hcc: IHardCodedConstraint) {
    return new FormGroup(
      {
        hConstraintName: new FormControl(hcc.hConstraintName, [Validators.required]),
        area: new FormControl(hcc.area, [Validators.required]),
        isDefaultNoConstraint: new FormControl(hcc.isDefaultNoConstraint),
        priority: new FormControl(hcc.priority), //[Validators.required, Validators.min(1), Validators.max(100)]),
        constraintContent: new FormControl(
          hcc.constraintContent,
          [Validators.required, HardConstraintValidators.createValidator(70)],
          [HardConstraintValidators.createAsyncValidator(this.objectService)]
        ),
      },
      { updateOn: 'change' }
    );
  }

  public onBtnAddConstraintClick() {
    if (!this.fgHardConstraints.valid) return;

    let hc = <IHardCodedConstraint>{
      hConstraintName: this._objectTableName,
      area: this.areas.find(a => a.areaName.toUpperCase() === 'GENERIC'),
      isDefaultNoConstraint: false,
      priority: 1,
      constraintContent: ' (  ) ',
    };
    (<FormArray>this.fgHardConstraints.get('faHardConstraints')).push(this.buildHardConstraintFormGroup(hc));
    this.ngZone.runOutsideAngular(() =>
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 0)
    );
  }

  public onButtonRemoveConstraintClick(hcIndex) {
    (<FormArray>this.fgHardConstraints.get('faHardConstraints')).removeAt(hcIndex);
    this.ngZone.runOutsideAngular(() =>
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 0)
    );
  }

  public onNextClick() {
    this.markAsTouched(<FormArray>this.fgHardConstraints.get('faHardConstraints'));
    if (!this.fgHardConstraints.valid) return;

    const stepData = this.fgHardConstraints.value;

    this.createObjectService.setData('hardCodedConstraints', stepData, false);

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_VARIANT_MAPPING}`], { relativeTo: this.route.parent });
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_CONSTRAINT}`], { relativeTo: this.route.parent });
  }

  public validateAreaToHConstraint(hConstraint) {
    if (!this.fgHardConstraints.get('faHardConstraints').errors) return false;

    const theError = this.fgHardConstraints.get('faHardConstraints').errors.diff;
    if (!theError) return false;

    return _.isEqual(hConstraint.area, theError.value.area);
  }
}
