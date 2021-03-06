export enum CreateObjectSteps {
  CG_META_OBJECT = 'cgMetaObject',
  CG_META_TECHNICAL_SETTING = 'cgMetaTechnicalSettings',
  CG_AREA_MAPPING = 'cgMetaAreaToObject',
  CG_COLUMN_MAPPING = 'cgMetaColumn',
  CG_CONSTRAINT = 'cgMetaConstraintToArea',
  CG_HARD_CONSTRAINT_TO_AREA = 'cgMetaHardConstraintToArea',
  CG_VARIANT_MAPPING = 'cgMetaVariantToObject',
  OBJECT_OVERVIEW = 'objectOverview',
}

export interface IStepData {
  stepTitle: string;
  label: string;
  url: string;
}

export type StepsData = {
  [key in (typeof CreateObjectSteps)[keyof typeof CreateObjectSteps]]: IStepData;
};

export const stepsData: StepsData = {
  [CreateObjectSteps.CG_META_OBJECT]: {
    stepTitle: 'Step 1 - cg_meta_objct',
    label: 'Object',
    url: `${CreateObjectSteps.CG_META_OBJECT}`,
  },
  [CreateObjectSteps.CG_META_TECHNICAL_SETTING]: {
    stepTitle: 'Step 2 - cg_meta_technical_setting',
    label: 'Technical Settings',
    url: `${CreateObjectSteps.CG_META_TECHNICAL_SETTING}`,
  },
  [CreateObjectSteps.CG_AREA_MAPPING]: {
    stepTitle: 'Step 3 - cg_meta_area_to_objct',
    label: 'Area Mapping',
    url: `${CreateObjectSteps.CG_AREA_MAPPING}`,
  },
  [CreateObjectSteps.CG_COLUMN_MAPPING]: {
    stepTitle: 'Step 4 - cg_meta_column',
    label: 'Columns',
    url: `${CreateObjectSteps.CG_COLUMN_MAPPING}`
  },
  [CreateObjectSteps.CG_CONSTRAINT]: {
    stepTitle: 'Step 5 - cg_meta_constraint_to_area',
    label: 'Constraints',
    url: `${CreateObjectSteps.CG_CONSTRAINT}`,
  },
  [CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA]: {
    stepTitle: 'Step 6 - cg_meta_hconstraint_to_area',
    label: 'HardConstraints',
    url: `${CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA}`,
  },
  [CreateObjectSteps.CG_VARIANT_MAPPING]: {
    stepTitle: 'Step 7 - cg_meta_variant_objct',
    label: 'Variants',
    url: `${CreateObjectSteps.CG_VARIANT_MAPPING}`,
  },
  [CreateObjectSteps.OBJECT_OVERVIEW]: {
    stepTitle: 'Step 8 - Review & Finalization',
    label: 'Review',
    url: `${CreateObjectSteps.OBJECT_OVERVIEW}`,
  },
};

export const stepsOrder = [
  CreateObjectSteps.CG_META_OBJECT,
  CreateObjectSteps.CG_META_TECHNICAL_SETTING,
  CreateObjectSteps.CG_AREA_MAPPING,
  CreateObjectSteps.CG_COLUMN_MAPPING,
  CreateObjectSteps.CG_CONSTRAINT,
  CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA,
  CreateObjectSteps.CG_VARIANT_MAPPING,
  CreateObjectSteps.OBJECT_OVERVIEW,
];
