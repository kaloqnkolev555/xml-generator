import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { ICGMetaGroup } from '@app/common/interfaces/cg-meta-group.interface';
import { ObjectsService } from '../objects.service';

@Injectable({
  providedIn: 'root',
})
export class CGMetaGroupResolver implements Resolve<Observable<ICGMetaGroup[]>> {
  constructor (
    private readonly objectsService: ObjectsService,
  ) {}

  public resolve() {
    return this.objectsService.getAllGroups();
  }
}
