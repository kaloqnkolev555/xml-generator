import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { greaterValue } from '@app/common/form-validators/greater-value.validator';
import { TextValidationRegex } from '@app/common/forms';
import { MarkAllAsTouched, MARK_CONTROLS_AS_TOUCHED } from '@app/common/forms/mark-all-as-touched.forms';
import { ICGMetaTable } from '@app/common/interfaces/cg-meta-table.interface';
import { IDD03 } from '@app/common/interfaces/dd03.interface';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { IExtractionLogic } from '@app/common/interfaces/extraction-logic-.interface';
import { IHelperTableName } from '@app/common/interfaces/helper-table.interface';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import {
  IcgMetaObjectOutput,
  IcgMetaTechnicalSetting,
} from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { ObjectsService } from '@app/xml-data-maintenance/objects/objects.service';
import { take } from 'rxjs/operators';
import { CreateObjectSteps } from '../../../objects-shared-module/resources';

const MAX_STRING_LENGTH = 70;

@Component({
  selector: 'app-cg-meta-technical-setting-form',
  templateUrl: './cg-meta-technical-setting-form.component.html',
  styleUrls: ['./cg-meta-technical-setting-form.component.scss'],
})
export class CgMetaTechnicalSettingFormComponent implements OnInit {
  public _canILeave = false;
  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_META_OBJECT}`;

  public cgMetaObjectDTO: IcgMetaObjectOutput;
  public cgMetaObjectTechnicalSettings: IcgMetaTechnicalSetting;

  public createForm: FormGroup;
  public extractionLogic: IExtractionLogic[] = [];
  public helperTableNames: IHelperTableName[] = [];
  public nrObject: string[] = [];
  public nrField: string[] = [];
  public tables: ICGMetaTable[] = [];
  public dd03: IDD03[] = [];
  public pkgSizeValue: number;
  public pkgSize2Value: number;

  public isDefaultSettingOptions = [
    {
      name: 'Yes',
      value: true,
    },
    {
      name: 'No',
      value: false,
    },
  ];

  public useNrMinMaxOptions = [
    {
      name: 'Yes',
      value: true,
    },
    {
      name: 'No',
      value: false,
    },
  ];

  public parallelOptions = [
    {
      name: 'Yes',
      value: true,
    },
    {
      name: 'No',
      value: false,
    },
  ];

  private textFieldValidators = [
    Validators.required,
    Validators.maxLength(MAX_STRING_LENGTH),
    Validators.pattern(TextValidationRegex),
  ];

  constructor(
    private readonly fb: FormBuilder,
    private readonly objectService: ObjectsService,
    private readonly createObjectService: CreateObjectService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) {}

  public create_object_errors: IErrorSet = {
    cgMetaExtractionLogic: [{ type: 'required', message: 'Mandatory field' }],
    mapCgMetaHelperTableName: [{ type: 'required', message: 'Mandatory field' }],
    dayByDay: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    daysPerLoop: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'max', message: 'Enter number not higher than 2147483647' },
    ],
    mapNrObject: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    mapNrField: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    pkgSize: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'max', message: 'Enter number not higher than 2147483647' },
    ],
    pkgSize2: [
      { type: 'validValue', message: 'The value must be less than pkgSize' },
      { type: 'max', message: 'Enter number not higher than 2147483647' },
    ],
    xFilename: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    docNbr: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    loopAt: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
    hashTotalField: [
      { type: 'maxlength', message: `Please fill in maximum ${MAX_STRING_LENGTH} symbols.` },
      { type: 'pattern', message: 'Field contains invalid character(s).' },
    ],
  };

  public selectedTable(tableName) {
    this.objectService
      .dd03GetFieldsForTable(tableName)
      .pipe(take(1))
      .subscribe(result => (this.dd03 = result));
  }

  ngOnInit() {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.helperTableNames = data.helperNames;
      this.extractionLogic = data.extractionLogic;
      this.tables = data.tables;
      this.nrObject = data.nrObject;
      this.nrField = data.nrField;
    });

    // for footer objects - set extraction logic to the one with empty name and disable form and validations
    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');
    this.cgMetaObjectTechnicalSettings = this.createObjectService.getData('cgMetaObjectTechnicalSettings');
    this.selectedTable(this.cgMetaObjectDTO.mapCgMetaTableName);

    // if this is a header object and extraction logic comes null, meaning that the entire step has been reset - we should set xFilename to the Table Name from Step 1
    if (!this.cgMetaObjectDTO.isFooter && !this.cgMetaObjectTechnicalSettings.cgMetaExtractionLogic) {
      this.cgMetaObjectTechnicalSettings.xFilename = this.cgMetaObjectDTO.mapCgMetaTableName;
    } else if (this.cgMetaObjectDTO.isFooter) {
      // set extraction logic to EMPTY
      this.cgMetaObjectTechnicalSettings.cgMetaExtractionLogic = this.extractionLogic.find(el => el.name.trim() === '');
      this.cgMetaObjectTechnicalSettings.xFilename = null;
    }

    this.buildTheForm(this.cgMetaObjectTechnicalSettings);

    this.handleExtractionLogic();

    // for footer objects - disable the entire form
    if (this.cgMetaObjectDTO.isFooter) {
      this.createForm.disable();
    }
  }

  // handles the change from the control - object is header!
  public onExtractionLogicChange(extractionLogic: IExtractionLogic) {
    // reset form data source by create object service
    this.cgMetaObjectTechnicalSettings = this.createObjectService.getDefaultData('cgMetaObjectTechnicalSettings');
    // set extraction logic
    this.cgMetaObjectTechnicalSettings.cgMetaExtractionLogic = extractionLogic;
    // set xFilename
    this.cgMetaObjectTechnicalSettings.xFilename = this.cgMetaObjectDTO.mapCgMetaTableName;

    this.handleExtractionLogic();
  }

  private handleExtractionLogic() {
    const extractionLogic = this.cgMetaObjectTechnicalSettings.cgMetaExtractionLogic;
    this.createForm.reset(this.cgMetaObjectTechnicalSettings);
    if (!extractionLogic) {
      this.createForm.disable();
      this.createForm.controls.cgMetaExtractionLogic.enable();
      return;
    }
    this.createForm.enable();
    switch (extractionLogic.name) {
      case '':
        this.createForm.disable();
        this.createForm.controls.cgMetaExtractionLogic.enable();
        this.createForm.controls.xFilename.enable();
        break;
      case '0':
        this.createForm.controls.dayByDay.disable();
        this.createForm.controls.daysPerLoop.disable();
        this.createForm.controls.mapNrObject.disable();
        this.createForm.controls.mapNrField.disable();
        this.createForm.controls.useNrMinMax.disable();
        this.createForm.controls.isParallel.disable();
        break;
      case '1':
        this.createForm.controls.dayByDay.disable();
        this.createForm.controls.daysPerLoop.disable();
        break;
      case '2':
      case '3':
        this.createForm.controls.mapNrObject.disable();
        this.createForm.controls.mapNrField.disable();
        this.createForm.controls.useNrMinMax.disable();
        break;
      case '4':
      case '5':
      case '6':
        this.createForm.controls.dayByDay.disable();
        this.createForm.controls.daysPerLoop.disable();
        this.createForm.controls.mapNrObject.disable();
        this.createForm.controls.mapNrField.disable();
        this.createForm.controls.useNrMinMax.disable();
        this.createForm.controls.isParallel.disable();
        break;
      case '9':
        this.createForm.disable();
        this.createForm.controls.cgMetaExtractionLogic.enable();
        this.createForm.controls.xFilename.enable();
        this.createForm.controls.docNbr.enable();
        this.createForm.controls.loopAt.enable();
        break;
    }
  }

  private buildTheForm(stepData: IcgMetaTechnicalSetting): void {
    this.createForm = this.fb.group(
      {
        cgMetaExtractionLogic: this.fb.control(stepData.cgMetaExtractionLogic, [Validators.required]),
        mapCgMetaHelperTableName: this.fb.control(stepData.mapCgMetaHelperTableName, [Validators.required]),
        dayByDay: this.fb.control(stepData.dayByDay, this.textFieldValidators),
        daysPerLoop: this.fb.control(stepData.daysPerLoop, [Validators.required, Validators.max(2147483647)]),
        mapNrObject: this.fb.control(stepData.mapNrObject, [
          Validators.required,
          Validators.pattern(TextValidationRegex),
        ]),
        mapNrField: this.fb.control(stepData.mapNrField, [
          Validators.required,
          Validators.pattern(TextValidationRegex),
        ]),
        useNrMinMax: this.fb.control(stepData.useNrMinMax, []),
        isParallel: this.fb.control(stepData.isParallel, []),
        pkgSize: this.fb.control(stepData.pkgSize, [Validators.required, Validators.max(2147483647)]),
        pkgSize2: this.fb.control(stepData.pkgSize2, [Validators.max(2147483647)]),
        xFilename: this.fb.control(stepData.xFilename, this.textFieldValidators),
        hashTotalField: this.fb.control(stepData.hashTotalField, [
          Validators.pattern(TextValidationRegex),
          Validators.maxLength(MAX_STRING_LENGTH),
        ]),
        isDefault: this.fb.control(stepData.isDefault, []),
        docNbr: this.fb.control(stepData.docNbr, [Validators.pattern(TextValidationRegex)]),
        loopAt: this.fb.control(stepData.loopAt, [Validators.required, Validators.pattern(TextValidationRegex)]),
      },
      { updateOn: 'submit' }
    );
    this.createForm
      .get('pkgSize2')
      .setValidators([greaterValue(this.createForm.get('pkgSize')), Validators.max(2147483647)]);
    this.createForm.get('pkgSize').valueChanges.subscribe(value => {
      this.createForm.get('pkgSize2').updateValueAndValidity();
    });
  }

  public canILeave() {
    return this._canILeave;
  }

  public nextStep(): void {
    this.markAsTouched(this.createForm);
    if (!this.cgMetaObjectDTO.isFooter && !this.createForm.valid) return;
    this.createForm.value.dd03Fields = this.dd03;
    const stepData = this.createForm.value;
    const isStepDifferent = this.createObjectService.isStepDifferent('cgMetaObjectTechnicalSettings', stepData);
    const isStepPassed = this.createObjectService.isStepPassed('cgMetaObjectTechnicalSettings');

    if (isStepDifferent && isStepPassed) {
      this.createObjectService.setData('cgMetaObjectTechnicalSettings', stepData, true);
    } else {
      this.createObjectService.setData('cgMetaObjectTechnicalSettings', stepData, false);
    }

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_AREA_MAPPING}`], { relativeTo: this.route.parent });
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_META_OBJECT}`], { relativeTo: this.route.parent });
  }
}
