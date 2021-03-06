import { Resolve } from '@angular/router';
import { ICGMetaTable } from '@app/common/interfaces/cg-meta-table.interface';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ObjectsService } from '../objects.service';

@Injectable({
  providedIn: 'root',
})
export class CGMetaTableResolver implements Resolve<ICGMetaTable[]> {
  constructor (
    private readonly objectsService: ObjectsService,
  ) {}

  public resolve(): Observable<ICGMetaTable[]> {
    return this.objectsService.getAllTables();
  }
}
