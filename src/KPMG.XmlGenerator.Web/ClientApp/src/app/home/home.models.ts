export interface IDbName {
  id: string;
  name: string;
  server: string;
  database: string;
  isActive: boolean;
  isDefault: boolean;
}

export interface ICgMetaObject {
  id: number;
  cgMetaObjectName: string;
  versionId: number;
  cgMetaGroupName: string;
  cgMetaTableName: string;
  isFooter: boolean;
  description: string;
  isDefault: string;
}

export interface ICgMetaVersion {
  id: number;
  versionName: string;
  displayString?: string;
}

export interface IDbScriptExecutionResult {
  dbSqlScriptFileName: string;
  executionResult: string;
  isSuccessful: boolean;
}
