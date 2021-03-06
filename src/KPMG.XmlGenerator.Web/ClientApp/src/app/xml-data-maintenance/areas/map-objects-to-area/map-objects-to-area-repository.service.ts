import { Observable, of } from 'rxjs';
import { IMapObjectsToArea } from './interfaces/map-objects-to-area.interface';

export class MapObjectsToAreaRepository {
  public getAreaToObject(): Observable<IMapObjectsToArea[]> {
    return of([]);
  }
}
