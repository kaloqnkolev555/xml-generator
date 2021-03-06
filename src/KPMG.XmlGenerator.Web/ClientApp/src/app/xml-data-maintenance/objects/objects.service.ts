import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IObject } from '../../common/interfaces';
import { BaseURLService } from '@app/common/base-url/base-url.service';
import { APP_CONFIG } from '../../common/base-url/app-settings.token';
import { IEnvironment } from 'environments/environment.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../../shared/services/local-storage.service';
import { ICGMetaGroup } from '@app/common/interfaces/cg-meta-group.interface';
import { ICGMetaTable } from '@app/common/interfaces/cg-meta-table.interface';
import { IDD03 } from '@app/common/interfaces/dd03.interface';
import { IHelperTableName } from '@app/common/interfaces/helper-table.interface';
import { IExtractionLogic } from '@app/common/interfaces/extraction-logic-.interface';
import { ISqlParseError, ICreateObjectOutput } from './interfaces/create-object-output.interface';
import { ServerValidationResult } from '../../common/interfaces/server-validation-result.interface';

@Injectable({
  providedIn: 'root',
})
export class ObjectsService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
  }

  public getAllObjects(): Observable<IObject[]> {
    return this.http.get<IObject[]>(this.constructUrl('/Object'));
  }

  public getAllGroups(): Observable<ICGMetaGroup[]> {
    return this.http.get<ICGMetaGroup[]>(this.constructUrl('/group'));
  }

  public getAllTables(): Observable<ICGMetaTable[]> {
    return this.http.get<ICGMetaTable[]>(this.constructUrl('/table'));
  }

  public dd03GetFieldsForTable(tableName: string): Observable<IDD03[]> {
    return this.http.get<IDD03[]>(this.constructUrl(`/DD03L/GetFieldsForTable`), {
      params: {
        tableName: [tableName],
      },
    });
  }

  public dd03GetField(tableName: string, fieldName: string): Observable<IDD03> {
    return this.http.get<IDD03>(this.constructUrl(`/DD03L/GetField`), {
      params: {
        tableName,
        fieldName,
      },
    });
  }

  public getHelperTable(): Observable<IHelperTableName[]> {
    return this.http.get<IHelperTableName[]>(this.constructUrl('/HelperTable'));
  }

  public getExtractionLogic(): Observable<IExtractionLogic[]> {
    return this.http.get<IExtractionLogic[]>(this.constructUrl('/extractionlogic'));
  }

  public getNrObject(): Observable<[]> {
    return this.http.get<[]>(this.constructUrl('/TechnicalSetting/NrObjct'));
  }

  public getNrField(): Observable<[]> {
    return this.http.get<[]>(this.constructUrl('/TechnicalSetting/NrField'));
  }

  public getConstraintOption(): Observable<[]> {
    return this.http.get<[]>(this.constructUrl('/ConstraintToArea/ConOption'));
  }

  public getConstraintValue(): Observable<[]> {
    return this.http.get<[]>(this.constructUrl('/ConstraintToArea/ConValue'));
  }

  public validateSqlWhereClause(sqlWhereClause: any): Observable<ISqlParseError[]> {
    return this.http.post<ISqlParseError[]>(this.constructUrl('/Db/ValidateSqlWhereClause'), sqlWhereClause);
  }

  public getVariantsWithConfigs(): Observable<[]> {
    return this.http.get<[]>(this.constructUrl('/variant/WithConfigs'));
  }

  public createObject(createObjectOutput) {
    return this.http.post(this.constructUrl('/Object'), createObjectOutput);
  }

  public loadObject(id: number): Observable<ICreateObjectOutput> {
    return this.http.get<ICreateObjectOutput>(this.constructUrl('/Object/WithAllRelations?id=' + id));
  }

  public deleteObject(data) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: data,
    };
    return this.http.delete<IObject[]>(this.constructUrl('/Object'), options);
  }

  public validateObjectName(name: string, id?: number): Observable<ServerValidationResult> {
    return this.http.post<ServerValidationResult>(this.constructUrl('/Object/ValidateName'), { name, id });
  }
}
