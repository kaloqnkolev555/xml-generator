import { Injectable } from '@angular/core';
import { ModalDialogService } from 'ngx-modal-dialog';
import { IConfirmationPopUpSettings } from '../interfaces';
import { ConfirmationPopupComponent } from './confirmation-popup/confirmation-popup.component';
import { ViewContainerRefService } from '@app/shared/services/view-container-ref.service';
import { Subject } from 'rxjs';

@Injectable()
export class ConfirmationPopUpService {
  constructor(
    private readonly modalService: ModalDialogService,
    private readonly viewContainerRefService: ViewContainerRefService
  ) {}

  public open(data: IConfirmationPopUpSettings) {
    const { viewContainerRef } = this.viewContainerRefService;
    const onClose = new Subject<boolean>();

    this.modalService.openDialog(viewContainerRef, {
      title: data.title,
      data,
      childComponent: ConfirmationPopupComponent,
      actionButtons: [
        {
          text: data.textButtonDecline || 'Cancel',
          buttonClass: 'btn btn-secondary',
          onAction: () => {
            onClose.next(false);
            return true;
          },
        },
        {
          text: data.textButtonAccept || 'OK',
          onAction: () => {
            onClose.next(true);
            return true;
          },
        },
      ],
    });

    return onClose;
  }
}
