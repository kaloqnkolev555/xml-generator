import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { CreateObjectService } from '../create-object.service';

@Injectable()
export class ResetServiceGuard implements CanDeactivate<any> {
  constructor(private readonly createObjectService: CreateObjectService) {}

  public canDeactivate() {
    this.createObjectService.resetState();
    return true;
  }
}
