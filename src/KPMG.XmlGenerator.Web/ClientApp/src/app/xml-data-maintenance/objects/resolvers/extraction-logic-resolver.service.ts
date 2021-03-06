import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ObjectsService } from '../objects.service';
import { IExtractionLogic } from '@app/common/interfaces/extraction-logic-.interface';

@Injectable({
  providedIn: 'root',
})
export class CGMetaExtractionLogicResolver implements Resolve<IExtractionLogic[]> {
  constructor(private readonly objectsService: ObjectsService) {}

  public resolve(): Observable<IExtractionLogic[]> {
    return this.objectsService.getExtractionLogic();
  }
}
