import { Injectable } from '@angular/core';
import { IDbName, ICgMetaVersion } from '../../home/home.models';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  private _dbKey: string = 'db';
  private _versionKey: string = 'version';

  public getDb(): IDbName {
    const lsValue = localStorage.getItem(this._dbKey);
    if (!!lsValue) {
      return <IDbName>JSON.parse(lsValue);
    }
    return null;
  }

  public setDb(db: IDbName) {
    localStorage.setItem(this._dbKey, JSON.stringify(db));
  }

  public getVersion(): ICgMetaVersion {
    const lsValue = localStorage.getItem(this._versionKey);
    if (!!lsValue) {
      return <ICgMetaVersion>JSON.parse(lsValue);
    }
    return null;
  }

  public setVersion(version: ICgMetaVersion) {
    localStorage.setItem(this._versionKey, JSON.stringify(version));
  }
}
