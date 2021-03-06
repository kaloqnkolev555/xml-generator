import { ICreateObjectOutput, IAreaToColumn, IcgMetaObjectOutput, IcgMetaTechnicalSetting, IMappedAreas } from './interfaces/create-object-output.interface';
import * as _ from 'lodash';
import { LocalStorageService } from '../../shared/services/local-storage.service';
import { CreateObjectSteps } from './objects-shared-module/resources';
import { IArea } from '@app/common/interfaces';
import { EventEmitter, Injectable } from '@angular/core';

type StepsForReset = {
  [key in keyof ICreateObjectOutput]: Array<keyof Omit<ICreateObjectOutput, key>>;
};

type StepsValidationState = {
  [key in keyof ICreateObjectOutput]: boolean;
};

type DTOToStepMap = {
  [key in keyof ICreateObjectOutput]: CreateObjectSteps;
};

@Injectable({
  providedIn: 'root'
})
export class CreateObjectService {
  public actionEmitter = new EventEmitter();

  private dtoToStepMap: DTOToStepMap = {
    cgMetaObjectDTO: CreateObjectSteps.CG_META_OBJECT,
    cgMetaObjectTechnicalSettings: CreateObjectSteps.CG_META_TECHNICAL_SETTING,
    mappedAreas: CreateObjectSteps.CG_AREA_MAPPING,
    mappedColumns: CreateObjectSteps.CG_COLUMN_MAPPING,
    cgMetaConstraintsArea: CreateObjectSteps.CG_CONSTRAINT,
    hardCodedConstraints: CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA,
    cgMetaVariantToObject: CreateObjectSteps.CG_VARIANT_MAPPING,
  };

  private stepsValidationState: StepsValidationState = {
    cgMetaObjectDTO: false,
    cgMetaObjectTechnicalSettings: false,
    mappedAreas: false,
    mappedColumns: false,
    cgMetaConstraintsArea: false,
    hardCodedConstraints: false,
    cgMetaVariantToObject: false,
  };

  private defaultState: ICreateObjectOutput = {
    cgMetaObjectDTO: {
      versionId: this.localStorageService.getVersion().id,
      cgMetaObjectName: '',
      mapCgMetaGroup: null,
      mapCgMetaTableName: '',
      isFooter: false,
      description: '',
      isDefault: true,
      id: null,
      fileName: '',
      hashTotalField: '',
      cgMetaHeaderObjectId: null,
      headerObjectName: null,
    },
    cgMetaObjectTechnicalSettings: {
      id: null,
      versionId: this.localStorageService.getVersion().id,
      cgMetaObjectName: '',
      cgMetaExtractionLogic: null,
      mapCgMetaHelperTableName: '',
      dayByDay: '',
      daysPerLoop: 0,
      mapNrObject: '',
      mapNrField: '',
      useNrMinMax: false,
      isParallel: false,
      pkgSize: 1000,
      pkgSize2: 0,
      xFilename: '',
      hashTotalField: null,
      isDefault: true, // TBD
      docNbr: '',
      loopAt: '',
      dd03Fields: [],
    },
    mappedAreas: {
      mappedAreas: [],
    },
    cgMetaConstraintsArea: {
      constraints: [],
    },
    hardCodedConstraints: {
      faHardConstraints: [],
    },
    cgMetaVariantToObject: {
      variants: [],
    },
    mappedColumns: [],
  };

  private data: ICreateObjectOutput = {
    cgMetaObjectDTO: this.defaultState.cgMetaObjectDTO,
    cgMetaObjectTechnicalSettings: this.defaultState.cgMetaObjectTechnicalSettings,
    mappedAreas: this.defaultState.mappedAreas,
    mappedColumns: this.defaultState.mappedColumns,
    cgMetaConstraintsArea: this.defaultState.cgMetaConstraintsArea,
    hardCodedConstraints: this.defaultState.hardCodedConstraints,
    cgMetaVariantToObject: this.defaultState.cgMetaVariantToObject,
  };

  constructor(private readonly localStorageService: LocalStorageService) {}

  private stepsForReset: StepsForReset = {
    cgMetaObjectDTO: ['cgMetaObjectTechnicalSettings', 'mappedAreas', 'mappedColumns', 'cgMetaConstraintsArea', 'hardCodedConstraints'],
    cgMetaObjectTechnicalSettings: ['mappedAreas', 'mappedColumns', 'cgMetaConstraintsArea', 'hardCodedConstraints'],
    mappedAreas: ['mappedColumns', 'cgMetaConstraintsArea', 'hardCodedConstraints'],
    mappedColumns: [],
    cgMetaConstraintsArea: [],
    hardCodedConstraints: [],
    cgMetaVariantToObject: [],
  };

  public getData<T extends keyof ICreateObjectOutput>(step: T): ICreateObjectOutput[T] {
    return this.data[step];
  }

  public getDefaultData<T extends keyof ICreateObjectOutput>(step: T): ICreateObjectOutput[T] {
    return Object.assign({}, this.defaultState[step]);
  }

  public setData<T extends keyof ICreateObjectOutput>(step: T, data: ICreateObjectOutput[T], resetSteps: boolean) {
    this.data[step] = Array.isArray(data) ? data : Object.assign({}, this.defaultState[step], data);
    this.stepsValidationState[step] = true;

    if (resetSteps) this.resetSteps(step);

    if (step === 'mappedAreas') this.setUpMappedColumns();
  }

  private setUpMappedColumns() {
    const mappedColumnsData: IAreaToColumn[] = this.data.mappedAreas.mappedAreas.map((area: IArea) => {
      const previousMapping = this.data.mappedColumns.find(c => c.areaName === area.areaName);
      return previousMapping || {
        versionId: area.versionId,
        areaName: area.areaName,
        id: area.id,
        mappedColumns: [],
      };
    });

    this.data['mappedColumns'] = mappedColumnsData;
  }

  private resetSteps(step: keyof ICreateObjectOutput) {
    this.stepsForReset[step].forEach(stepForReset => {
      this.data[stepForReset] = this.defaultState[stepForReset];
      this.stepsValidationState[stepForReset] = false;
    });
  }

  public isStepDifferent<T extends keyof ICreateObjectOutput>(step: T, data: ICreateObjectOutput[T]): boolean {
    switch (this.dtoToStepMap[step]) {
      case CreateObjectSteps.CG_META_OBJECT: // compare isFooter and the mapped table
        const currentObjectData = (({ mapCgMetaTableName, isFooter }) => ({ mapCgMetaTableName, isFooter }))(<IcgMetaObjectOutput>this.data[step]);
        const postedObjectData = (({ mapCgMetaTableName, isFooter }) => ({ mapCgMetaTableName, isFooter }))(<IcgMetaObjectOutput>data);
        return !_.isEqual(currentObjectData, postedObjectData);
      case CreateObjectSteps.CG_META_TECHNICAL_SETTING: // compare only the extraction logic
        const currentTechnicalSettingsData = (({ cgMetaExtractionLogic }) => ({ cgMetaExtractionLogic }))(<IcgMetaTechnicalSetting>this.data[step]);
        const postedTechnicalSettingsData = (({ cgMetaExtractionLogic }) => ({ cgMetaExtractionLogic }))(<IcgMetaTechnicalSetting>data);
        return !_.isEqual(currentTechnicalSettingsData, postedTechnicalSettingsData);
      case CreateObjectSteps.CG_AREA_MAPPING: // determine if any previously mapped area has been unmapped
        return !(<IMappedAreas>this.data[step]).mappedAreas.every(a => !!(<IMappedAreas>data).mappedAreas.find(x => x.areaName === a.areaName));
      default:
        return false;
    }
  }

  public isStepPassed(step: keyof ICreateObjectOutput) {
    return this.stepsValidationState[step];
  }

  public getAllData(): ICreateObjectOutput {
    return this.data;
  }

  public firstInvalidStep(): CreateObjectSteps {
    const invalidStep = Object.keys(this.stepsValidationState).find(key => !this.stepsValidationState[key]);
    return this.dtoToStepMap[invalidStep];
  }

  public resetState() {
    this.data = Object.assign({}, this.defaultState);
    Object.keys(this.stepsValidationState).reduce((acc, value) => {
      acc[value] = false;
      return acc;
    }, this.stepsValidationState);
  }

  public setAllData(objectData: ICreateObjectOutput): void {
    this.data = objectData;
    this.stepsValidationState = {
      cgMetaObjectDTO: true,
      cgMetaObjectTechnicalSettings: true,
      mappedAreas: true,
      mappedColumns: true,
      cgMetaConstraintsArea: true,
      hardCodedConstraints: true,
      cgMetaVariantToObject: true,
    }
  }
}
