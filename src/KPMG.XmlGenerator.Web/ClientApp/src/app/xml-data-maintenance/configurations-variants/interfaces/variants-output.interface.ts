export interface IVariantsOutput {
  variant: { versionId: string | number; variantName: string };
  templateCgMetaVariantIdColumn?: number;
  mapMetaObjctIdColumns?: number[];
}
