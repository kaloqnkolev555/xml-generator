import { Resolve } from '@angular/router';
import { IDD03 } from '@app/common/interfaces/dd03.interface';
import { CreateObjectService } from '../../create-object.service';
import { Injectable } from '@angular/core';
import { ObjectsService } from '../../objects.service';

@Injectable()
export class DD03LColumnResolver implements Resolve<IDD03[]> {
  constructor(
    private readonly createObjectService: CreateObjectService,
    private readonly objectService: ObjectsService,
  ) {}

  public resolve() {
    const tableName = this.createObjectService.getData('cgMetaObjectDTO').mapCgMetaTableName;
    return this.objectService.dd03GetFieldsForTable(tableName);
  }
}
