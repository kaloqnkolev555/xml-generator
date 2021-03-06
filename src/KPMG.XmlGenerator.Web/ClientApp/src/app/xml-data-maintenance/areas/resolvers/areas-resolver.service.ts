import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IArea } from '@app/common/interfaces';
import { AreasService } from '../areas.service';

@Injectable({
  providedIn: 'root',
})
export class AreasResolver implements Resolve<Observable<IArea[]>> {
  constructor(private readonly areasService: AreasService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IArea[]> {
    return this.areasService.getAllAreas();
  }
}
