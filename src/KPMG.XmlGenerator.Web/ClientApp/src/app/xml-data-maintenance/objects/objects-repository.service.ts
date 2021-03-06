import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IObject } from '../../common/interfaces';

@Injectable({
  providedIn: 'root',
})
export class ObjectsRepository {
  public getAllObjects(): Observable<IObject[]> {
    return of([
      {
        versionId: 1,
        cgMetaObjectName: 'A002',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 1,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A003',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 2,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A003',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 3,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A003',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 4,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A004',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 5,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A005',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 6,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A007',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 7,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A008',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 8,
      },
      {
        versionId: 1,
        cgMetaObjectName: 'A010',
        cgMetaGroupName: 'groupName',
        cgMetaTableName: 'tableName',
        isFooter: false,
        description: '',
        isDefault: '1',
        id: 9,
      },
    ]);
  }
}
