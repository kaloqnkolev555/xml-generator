import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IArea, IAreaForRefTable } from '../../common/interfaces';
import { BaseURLService } from '../../common/base-url/base-url.service';
import { IEnvironment } from 'environments/environment.interface';
import { APP_CONFIG } from '@app/common/base-url/app-settings.token';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IAreaOutput } from './interfaces/area-output.interface';
import { IEditAreaOutput } from './interfaces/edit-area-output.interface';
import { LocalStorageService } from '../../shared/services/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AreasService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
  }

  public getAllAreas(): Observable<IArea[]> {
    return this.http.get<IArea[]>(this.constructUrl('/Area'));
  }

  public createArea(data: IAreaOutput): Observable<IArea> {
    debugger
    data.area.versionId = this.localStorageService.getVersion().id;
    return this.http.post<IArea>(this.constructUrl('/Area'), data);
  }

  public deleteArea(data) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: data,
    };
    return this.http.delete<IArea>(this.constructUrl('/Area'), options);
  }

  public editArea(data: IEditAreaOutput): Observable<IArea> {
    data.versionId = this.localStorageService.getVersion().id;
    return this.http.put<IArea>(this.constructUrl('/Area'), data);
  }

  public GetAreasForRefTable(tableName: string): Observable<IAreaForRefTable[]> {
    return this.http.get<IAreaForRefTable[]>(this.constructUrl('/Area/GetAreasForRefTable'), { params: { tableName } });
  }
}
