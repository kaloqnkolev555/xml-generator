import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { IDbName, ICgMetaObject, ICgMetaVersion, IDbScriptExecutionResult } from './home.models';
import { BaseURLService } from '../common/base-url/base-url.service';
import { APP_CONFIG } from '../common/base-url/app-settings.token';
import { IEnvironment } from '../../environments/environment.interface';
import { LocalStorageService } from '../shared/services/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class HomeService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
}

  public getDbNames(): Observable<IDbName[]> {
    return this.http.get<IDbName[]>(this.constructUrl('/db')).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public getVersions(dbId: string): Observable<ICgMetaVersion[]> {
    return this.http.get<ICgMetaVersion[]>(this.constructUrl('/version')).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public applyAllSqlScripts(): Observable<IDbScriptExecutionResult[]> {
    return this.http.get<IDbScriptExecutionResult[]>(this.constructUrl('/db/ApplyAllSqlScripts')).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public getObjects(): Observable<ICgMetaObject[]> {
    return this.http.get<ICgMetaObject[]>(this.getBaseUrl() + 'api/object').pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public postObject() {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    const newObject = <ICgMetaObject>{
      versionId: 1,
      cgMetaObjectName: '/TEST/TEST',
      cgMetaGroupName: 'cus',
      cgMetaTableName: '/SAPSLL/BOPHD',
      isFooter: false,
      description: 'Test 123 456',
      isDefault: '1',
    };

    return this.http
      .post<string>(this.getBaseUrl() + 'api/object', JSON.stringify(newObject), { headers: headers })
      .pipe(
        catchError(error => {
          return throwError(error);
        })
      );
  }

  private getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
  }
}
