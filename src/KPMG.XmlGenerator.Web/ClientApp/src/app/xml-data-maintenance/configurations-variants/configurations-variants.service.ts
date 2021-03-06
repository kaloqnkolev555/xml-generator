import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseURLService } from '../../common/base-url/base-url.service';
import { IEnvironment } from 'environments/environment.interface';
import { APP_CONFIG } from '@app/common/base-url/app-settings.token';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IVariantsOutput } from './interfaces/variants-output.interface';
import { IVariants } from '../../common/interfaces/variants.interface';
import { IConfigurationOutput } from './interfaces/configuration-output.interface';
import { IConfigurations } from '../../common/interfaces/configurations.interface';
import { IVariantUpdateOutput } from './interfaces/variant-update-output';
import { IMapObjectsToVariant } from './variant-object-mapping/interfaces/variant-object-mapping.interface';
import { VariantObjectMappingCreateOutput } from './variant-object-mapping/interfaces/variant-object-mapping-create-output.interface';
import { IMapConfigurationToVariants } from './variant-object-mapping/interfaces/configiration-variants-mapping.interface';
import { IConfigurationVariantsMappingOutput } from './variant-object-mapping/interfaces/configuration-variants-mapping-output';
import { LocalStorageService } from '../../shared/services/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class VariantsService extends BaseURLService {
  constructor(
    @Inject(APP_CONFIG)
    protected readonly config: IEnvironment,
    protected readonly localStorageService: LocalStorageService,
    private readonly http: HttpClient
  ) {
    super(config, localStorageService);
  }

  public getAllVariants(): Observable<IVariants[]> {
    return this.http.get<IVariants[]>(this.constructUrl('/Variant'));
  }

  public createVariant(data: IVariantsOutput): Observable<IVariants> {
    data.variant.versionId = this.localStorageService.getVersion().id;
    return this.http.post<IVariants>(this.constructUrl('/Variant'), data);
  }

  public editVariant(data: IVariantUpdateOutput): Observable<IVariants> {
    data.versionId = this.localStorageService.getVersion().id;
    return this.http.put<IVariants>(this.constructUrl('/Variant'), data);
  }

  public getVariantToObject(variantId: number): Observable<IMapObjectsToVariant> {
    return this.http.get<IMapObjectsToVariant>(this.constructUrl(`/VariantToObject/${variantId}`));
  }

  public getConfigurationToVariant(configurationId: number): Observable<IMapConfigurationToVariants> {
    return this.http.get<IMapConfigurationToVariants>(this.constructUrl(`/ConfigurationToVariant/${configurationId}`))
  }

  public mapConfigurationToVariant(data: IConfigurationVariantsMappingOutput): Observable<IMapConfigurationToVariants> {
    return this.http.post<IMapConfigurationToVariants>(this.constructUrl('/ConfigurationToVariant'), data);
  }

  public deleteVariant(data) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: data,
    };
    return this.http.delete<IVariants>(this.constructUrl('/Variant'), options);
  }

  public mapObjectsToVariant(data: VariantObjectMappingCreateOutput): Observable<IMapObjectsToVariant> {
    return this.http.post<IMapObjectsToVariant>(this.constructUrl(`/VariantToObject`), data);
  }

  public getAllConfigurations(): Observable<IConfigurations[]> {
    return this.http.get<IConfigurations[]>(this.constructUrl('/Configuration'));
  }

  public createConfiguration(data) {
    data.configuration.versionId = this.localStorageService.getVersion().id;
    return this.http.post(this.constructUrl('/Configuration'), data);
  }

  public editConfiguration(data: IConfigurationOutput): Observable<IConfigurations> {
    data.versionId = this.localStorageService.getVersion().id;
    return this.http.put<IConfigurations>(this.constructUrl('/Configuration'), data);
  }

  public deleteConfiguration(data) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: data,
    };
    return this.http.delete<IConfigurations>(this.constructUrl('/Configuration'), options);
  }
}
