import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IVariants } from '@app/common/interfaces';
import { VariantsService } from '../configurations-variants.service';

@Injectable({
  providedIn: 'root',
})
export class VariantsResolver implements Resolve<Observable<IVariants[]>> {
  constructor(private readonly variantsService: VariantsService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IVariants[]> {
    return this.variantsService.getAllVariants();
  }
}
