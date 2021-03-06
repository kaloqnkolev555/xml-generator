import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IConfigurations } from '../../../common/interfaces';
import { VariantsService } from '../configurations-variants.service';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationsResolver implements Resolve<Observable<IConfigurations[]>> {
  constructor(private readonly variantsService: VariantsService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IConfigurations[]> {
    return this.variantsService.getAllConfigurations();
  }
}
