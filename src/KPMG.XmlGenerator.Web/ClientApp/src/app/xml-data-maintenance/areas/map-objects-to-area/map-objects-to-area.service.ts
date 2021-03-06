import { Injectable, Inject } from '@angular/core';
import { IMapObjectsToArea } from './interfaces/map-objects-to-area.interface';
import { Observable } from 'rxjs';
import { APP_CONFIG } from '@app/common/base-url/app-settings.token';
import { IEnvironment } from 'environments/environment.interface';
import { BaseURLService } from '@app/common/base-url/base-url.service';
import { HttpClient } from '@angular/common/http';
import { IMapObjectsToAreaOutput } from './interfaces/map-objects-to-area-output.interface';
import { LocalStorageService } from '../../../shared/services/local-storage.service';

@Injectable()
export class MapObjectsToAreaService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
  }

  public getAreaToObject(areaId: number): Observable<IMapObjectsToArea> {
    return this.http.get<IMapObjectsToArea>(this.constructUrl(`/AreaToObject/${areaId}`));
  }

  public mapObjectsToArea(data: IMapObjectsToAreaOutput): Observable<IMapObjectsToArea> {
    return this.http.post<IMapObjectsToArea>(this.constructUrl('/AreaToObject'), data);
  }
}
