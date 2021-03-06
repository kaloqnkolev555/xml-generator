import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IArea } from '../../common/interfaces';

@Injectable({
  providedIn: 'root',
})
export class AreasRepository {
  public getAllAreas(): Observable<IArea[]> {
    return of([
      {
        versionId: 1,
        areaName: 'Tax_Basic',
        id: 1,
      },
      {
        versionId: 1,
        areaName: 'Tax_Basic1',
        id: 2,
      },
      {
        versionId: 1,
        areaName: 'Tax_Basic3',
        id: 3,
      },
      {
        versionId: 1,
        areaName: 'Tax_Basic4',
        id: 4,
      }
    ]);
  }
}
