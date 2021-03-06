import { Observable } from 'rxjs';
import { Injectable, ViewContainerRef } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';

export interface CanComponentFDeactivate {
  canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}

@Injectable({
  providedIn: 'root',
})
export class CanDeactivateFormChangesGuard implements CanDeactivate<ViewContainerRef> {
  constructor(private readonly confirmationPopUp: ConfirmationPopUpService) {}

  canDeactivate(component: any, route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (component.canILeave && component.canILeave()) {
      return true;
    }

    return this.confirmationPopUp.open({
      title: 'Are you sure you want to leave?',
      description: 'If you leave this page all changes will be discarded. Please confirm.',
    });
  }
}
