import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ObjectsService } from '../objects.service';
import { IHelperTableName } from '@app/common/interfaces/helper-table.interface';

@Injectable({
  providedIn: 'root',
})
export class CGMetaHelperNamesResolver implements Resolve<IHelperTableName[]> {
  constructor(private readonly objectsService: ObjectsService) {}

  public resolve(): Observable<IHelperTableName[]> {
    return this.objectsService.getHelperTable();
  }
}
