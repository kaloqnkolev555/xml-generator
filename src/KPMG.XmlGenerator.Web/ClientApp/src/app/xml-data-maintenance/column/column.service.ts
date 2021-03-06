import { Injectable, Inject } from '@angular/core';
import { BaseURLService } from '@app/common/base-url/base-url.service';
import { APP_CONFIG } from '@app/common/base-url/app-settings.token';
import { IEnvironment } from 'environments/environment.interface';
import { LocalStorageService } from '@app/shared/services/local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IColumn } from '@app/common/interfaces';

@Injectable({ providedIn: 'root' })
export class ColumnService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
  }

  public getColumnsByObjectNameAreaName(objectName: string, areaName: string): Observable<IColumn[]> {
    return this.http.get<IColumn[]>(this.constructUrl('/Column/GetColumnsByObjectNameAreaName'), {
      params: {
        objectName,
        areaName,
      },
    });
  }
}
