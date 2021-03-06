import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ObjectsService } from '../objects.service';
import { Observable } from 'rxjs';
import { IObject } from '../../../common/interfaces';

@Injectable({
  providedIn: 'root',
})
export class ObjectsResolver implements Resolve<Observable<IObject[]>> {
  constructor(private readonly objectsService: ObjectsService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IObject[]> {
    return this.objectsService.getAllObjects();
  }
}
