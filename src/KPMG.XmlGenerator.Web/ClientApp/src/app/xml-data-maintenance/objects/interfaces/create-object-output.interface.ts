import { ICGMetaGroup } from '../../../common/interfaces/cg-meta-group.interface';
import { IExtractionLogic } from '../../../common/interfaces/extraction-logic-.interface';
import { IArea, IColumn } from '../../../common/interfaces';

export interface IcgMetaObjectOutput {
  versionId: number;
  cgMetaObjectName: string;
  mapCgMetaGroup: ICGMetaGroup;
  mapCgMetaTableName: string;
  isFooter: boolean;
  description: string;
  isDefault: boolean;
  id?: number;
  fileName: string;
  hashTotalField: string;
  cgMetaHeaderObjectId: number;
  headerObjectName: string;
}

export interface IcgMetaTechnicalSetting {
  id: number;
  versionId: number;
  cgMetaObjectName: string;
  cgMetaExtractionLogic: IExtractionLogic;
  mapCgMetaHelperTableName: string;
  dayByDay: string;
  daysPerLoop: number;
  mapNrObject: string;
  mapNrField: string;
  useNrMinMax: boolean;
  isParallel: boolean;
  pkgSize: number;
  pkgSize2: number;
  xFilename: string;
  hashTotalField: string;
  isDefault: boolean; // TBD
  docNbr: string;
  loopAt: string;
  dd03Fields: [];
}

export interface IMappedAreas {
  mappedAreas: IArea[];
}

export interface IAreaToColumn extends IArea {
  mappedColumns: IColumn[];
}

export interface IConstraint {
  constraintField?: string;
  constraintOption?: string;
  constraintValue?: string;
  area?: IArea;
  extractionLogicName?: string;
  inSQL: boolean;
  priority: number;
}

export interface IConstraintToAreaOutput {
  constraints: IConstraint[];
}

export interface IHardCodedConstraint {
  hConstraintName?: string;
  area?: IArea;
  isDefaultNoConstraint: boolean;
  priority: number;
  constraintContent?: string;
}

export interface IHardCodedConstraintsFormData {
  faHardConstraints:  IHardCodedConstraint[];
}

export interface IConfiguration {
  versionId: number;
  configurationName: string;
  variantName: string;
  id: number;
}

export interface IVariant {
  versionId: number;
  variantName: string;
  id: number;
  mappedConfigurations: IConfiguration[];
}
export interface IVariantOutput {
  variants: IVariant[];
}
export interface ISqlParseError {
  number: number;
  offset: number;
  line: number;
  column: number;
  message: string;
}

export interface ICreateObjectOutput {
  cgMetaObjectDTO: IcgMetaObjectOutput;
  cgMetaObjectTechnicalSettings: IcgMetaTechnicalSetting;
  mappedAreas: IMappedAreas;
  mappedColumns: IAreaToColumn[];
  cgMetaConstraintsArea: IConstraintToAreaOutput;
  hardCodedConstraints: IHardCodedConstraintsFormData;
  cgMetaVariantToObject: IVariantOutput;
}
