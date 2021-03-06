import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ObjectsService } from '../objects.service';

@Injectable({
  providedIn: 'root',
})
export class CGMetaTechnicalSettingsNrFieldResolver implements Resolve<[]> {
  constructor(private readonly objectsService: ObjectsService) {}

  public resolve(): Observable<[]> {
    return this.objectsService.getNrField();
  }
}
