import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate } from '@angular/router';
import { CreateObjectService } from '../create-object.service';
import { ObjectsService } from '../objects.service';
import { tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class UpdateObjectResolver implements CanActivate {
  constructor(
    private readonly objectService: ObjectsService,
    private readonly createObjectService: CreateObjectService
  ) {}

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.objectService.loadObject(route.params.objectId).pipe(
      tap(result => this.createObjectService.setAllData(result)),
      map(value => !!value)
    );
  }
}
