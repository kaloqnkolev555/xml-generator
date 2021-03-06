import { Resolve } from '@angular/router';
import { Injectable } from '@angular/core';
import { AreasService } from '@app/xml-data-maintenance/areas/areas.service';
import { CreateObjectService } from '../../create-object.service';
import { IAreaForRefTable } from '@app/common/interfaces';

@Injectable()
export class GetAreasForRefTableResolver implements Resolve<IAreaForRefTable[]> {
  constructor(
    private readonly createObjectService: CreateObjectService,
    private readonly areaService: AreasService,
  ) {}

  public resolve() {
    const tableName = this.createObjectService.getData('cgMetaObjectDTO').mapCgMetaTableName;
    return this.areaService.GetAreasForRefTable(tableName);
  }
}
