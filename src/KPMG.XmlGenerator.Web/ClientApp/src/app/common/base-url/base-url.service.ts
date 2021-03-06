import { IEnvironment } from 'environments/environment.interface';
import { LocalStorageService } from '../../shared/services/local-storage.service';
import { APP_CONFIG } from './app-settings.token';
import { Inject } from '@angular/core';

export abstract class BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService
  ) {}

  protected constructUrl(apiEndPoint: string) {
    const queryConcatenator: string = apiEndPoint.indexOf('?') > -1 ? '&' : '?';
    const db = this.localStorageService.getDb();
    const v = this.localStorageService.getVersion();
    return `${this.config.api.BASE_URL}${apiEndPoint}${queryConcatenator}DB=${!!db ? db.id : ''}&V=${!!v ? v.id : ''}`;
  }
}
