import { Injectable, ViewContainerRef } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ViewContainerRefService {
  private _viewContainerRef: ViewContainerRef;

  public get viewContainerRef() {
    return this._viewContainerRef;
  }

  public set viewContainerRef(ref: ViewContainerRef) {
    this._viewContainerRef = ref;
  }
}
