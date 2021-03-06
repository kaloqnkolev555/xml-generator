import { Component, OnInit, Inject, NgZone, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { ICGMetaTable } from '@app/common/interfaces/cg-meta-table.interface';
import { ICGMetaGroup } from '@app/common/interfaces/cg-meta-group.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { take, tap, switchMap, startWith, filter } from 'rxjs/operators';
import { ICgMetaObject } from '@app/home/home.models';
import { IToggleButtonOption } from '@app/common/toggle-button/components';
import { MarkAllAsTouched, MARK_CONTROLS_AS_TOUCHED } from '@app/common/forms/mark-all-as-touched.forms';
import { IDD03 } from '@app/common/interfaces/dd03.interface';
import { ObjectsService } from '@app/xml-data-maintenance/objects/objects.service';
import { TextValidationRegex } from '@app/common/forms';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import {
  IcgMetaObjectOutput,
  ICreateObjectOutput,
} from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { CreateObjectSteps } from '../../../objects-shared-module/resources';
import { ObjectNameValidators } from '../../../object-name-validator';
import { Subject } from 'rxjs';

enum FormsTypes {
  GENERIC_OR_HEADER = 'Generic or Header',
  FOOTER = 'Footer',
}

const MAX_STRING_LENGTH = 70;

@Component({
  selector: 'app-cg-meta-object-form',
  templateUrl: './cg-meta-object-form.component.html',
  styleUrls: ['./cg-meta-object-form.component.scss'],
  host: { class: 'w-100' },
})
export class CgMetaObjectFormComponent implements OnInit, OnDestroy {
  private _canILeave = false;
  public formSubmitSubject$ = new Subject();

  public formsTypes = FormsTypes;
  public selectedFormType = false;
  public formTypesOptions: IToggleButtonOption[] = [
    {
      name: FormsTypes.GENERIC_OR_HEADER,
      isActive: true,
      value: false,
    },
    {
      name: FormsTypes.FOOTER,
      value: true,
    },
  ];

  public useObjectAsTemplateCTR = new FormControl();
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

  public tables: ICGMetaTable[] = [];
  public groups: ICGMetaGroup[] = [];
  public cgMetaObjects: ICgMetaObject[] = [];
  public dd03: IDD03[] = [];

  public cdMetaObjectForm: FormGroup;

  public groupCTR = new FormControl();

  public object_errors: IErrorSet = {
    cgMetaObjectName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` },
      { type: 'objectNameErrors', message: 'Please enter unique name' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    mapCgMetaGroup: [{ type: 'required', message: 'Mandatory field' }],
    description: [{ type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` }],
    mapCgMetaTableName: [{ type: 'required', message: 'Mandatory field' }],
    fileName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    cgMetaHeaderObjectId: [{ type: 'required', message: 'Mandatory field' }],
    hashTotalField: [
      { type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
  };

  public cgMetaObjectDTO: IcgMetaObjectOutput;

  constructor(
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly fb: FormBuilder,
    private readonly objectService: ObjectsService,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly createObjectService: CreateObjectService,
    private readonly ngZone: NgZone
  ) {}

  ngOnInit() {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.tables = data.tables;
      this.groups = data.groups;
      this.cgMetaObjects = data.objects;
    });

    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');

    this.buildTheForm(this.cgMetaObjectDTO);

    this.changeForm(this.cdMetaObjectForm.get('isFooter').value);

    const { mapCgMetaTableName } = this.cgMetaObjectDTO;
    if (mapCgMetaTableName !== '') {
      this.selectedTable(mapCgMetaTableName, false);
    }

    this.formSubmitSubject$
      .pipe(
        tap(() => this.markAsTouched(this.cdMetaObjectForm)),
        switchMap(() =>
          this.cdMetaObjectForm.statusChanges.pipe(
            startWith(this.cdMetaObjectForm.status),
            filter(status => status !== 'PENDING'),
            take(1)
          )
        ),
        filter(status => status === 'VALID')
      )
      .subscribe(_ => this.nextClicked());
  }

  private buildTheForm(stepData: IcgMetaObjectOutput) {
    this.cdMetaObjectForm = this.fb.group(
      {
        id: this.fb.control(stepData.id),
        cgMetaObjectName: this.fb.control(
          stepData.cgMetaObjectName,
          [Validators.required, Validators.maxLength(MAX_STRING_LENGTH), Validators.pattern('^[a-zA-Z\\_\\d\\-\\/]+$'),],
          [ObjectNameValidators.createAsyncValidator(this.objectService, stepData.id)]
        ),
        isFooter: this.fb.control(stepData.isFooter),
        description: this.fb.control(stepData.description, [Validators.maxLength(MAX_STRING_LENGTH)]),
        isDefault: this.fb.control(stepData.isDefault),
      },
      { updateOn: 'submit' }
    );
  }

  private addGenericHeaderControls(stepData: IcgMetaObjectOutput) {
    this.cdMetaObjectForm.addControl('mapCgMetaGroup', this.fb.control(stepData.mapCgMetaGroup, [Validators.required]));
    this.cdMetaObjectForm.addControl(
      'mapCgMetaTableName',
      this.fb.control(stepData.mapCgMetaTableName, [Validators.required])
    );
  }

  private removeGenericHeaderControls() {
    this.cdMetaObjectForm.removeControl('mapCgMetaGroup');
    this.cdMetaObjectForm.removeControl('mapCgMetaTableName');
  }

  private addFooterControls(stepData: IcgMetaObjectOutput) {
    this.cdMetaObjectForm.addControl(
      'mapCgMetaTableName',
      this.fb.control(stepData.mapCgMetaTableName, Validators.required)
    );
    this.cdMetaObjectForm.addControl(
      'cgMetaHeaderObjectId',
      this.fb.control(stepData.cgMetaHeaderObjectId, [Validators.required])
    );
    this.cdMetaObjectForm.addControl(
      'fileName',
      this.fb.control(stepData.fileName, [Validators.required, Validators.pattern(TextValidationRegex)])
    );
    this.cdMetaObjectForm.addControl(
      'hashTotalField',
      this.fb.control(stepData.hashTotalField, [
        Validators.pattern(TextValidationRegex),
        Validators.maxLength(MAX_STRING_LENGTH),
      ])
    );
  }

  private removeFooterControls() {
    this.cdMetaObjectForm.removeControl('mapCgMetaTableName');
    this.cdMetaObjectForm.removeControl('cgMetaHeaderObjectId');
    this.cdMetaObjectForm.removeControl('fileName');
    this.cdMetaObjectForm.removeControl('hashTotalField');
  }

  public selectedTable(tableName: string, setFileName: boolean) {
    this.objectService
      .dd03GetFieldsForTable(tableName)
      .pipe(take(1))
      .subscribe(result => void (this.dd03 = result));

    if (setFileName) this.cdMetaObjectForm.get('fileName').setValue(tableName, { emitEvent: false });
  }

  public changeForm(isFooter: boolean) {
    if (isFooter) {
      this.removeGenericHeaderControls();
      this.addFooterControls(this.cgMetaObjectDTO);
    } else {
      this.removeFooterControls();
      this.addGenericHeaderControls(this.cgMetaObjectDTO);
    }

    this.selectedFormType = isFooter;

    this.ngZone.runOutsideAngular(() =>
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 0)
    );
  }

  public canILeave() {
    return this._canILeave;
  }

  public nextClicked() {
    if (!this.cdMetaObjectForm.valid) return;

    const stepData = this.getEnrichedStepData();

    const isStepDifferent = this.createObjectService.isStepDifferent('cgMetaObjectDTO', stepData);
    const isStepPassed = this.createObjectService.isStepPassed('cgMetaObjectDTO');

    if (isStepDifferent && isStepPassed) {
      this.createObjectService.setData('cgMetaObjectDTO', stepData, true);
    } else {
      this.createObjectService.setData('cgMetaObjectDTO', stepData, false);
    }

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_META_TECHNICAL_SETTING}`], { relativeTo: this.route.parent });
  }

  private getEnrichedStepData(): IcgMetaObjectOutput {
    const stepData = <IcgMetaObjectOutput>this.cdMetaObjectForm.value;

    // set headerObjectName
    stepData.headerObjectName = stepData.isFooter
      ? this.cgMetaObjects.find(o => o.id === stepData.cgMetaHeaderObjectId).cgMetaObjectName
      : null;

    return stepData;
  }

  public loadTemplate(): void {
    const selectedTemplateObjectId = <number>this.useObjectAsTemplateCTR.value;
    if (!!selectedTemplateObjectId) {
      this.objectService
        .loadObject(selectedTemplateObjectId)
        .pipe(take(1))
        .subscribe((objData: ICreateObjectOutput) => {
          objData.cgMetaObjectDTO.id = null;
          this.createObjectService.setAllData(objData);

          this.cgMetaObjectDTO = objData.cgMetaObjectDTO;

          if (objData.cgMetaObjectDTO.isFooter !== this.selectedFormType) {
            this.changeForm(objData.cgMetaObjectDTO.isFooter);
          }

          this.selectedTable(objData.cgMetaObjectDTO.mapCgMetaTableName, false);

          delete objData.cgMetaObjectDTO.cgMetaObjectName;
          delete objData.cgMetaObjectDTO.description;

          this.cdMetaObjectForm.patchValue(objData.cgMetaObjectDTO, { emitEvent: true });
        });
    }
  }

  public ngOnDestroy() {
    this.formSubmitSubject$.complete();
  }
}
