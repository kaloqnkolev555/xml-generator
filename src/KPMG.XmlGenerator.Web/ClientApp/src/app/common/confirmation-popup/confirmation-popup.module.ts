import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationPopupComponent } from './components/confirmation-popup/confirmation-popup.component';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { ConfirmationPopUpService } from './components/confirmation-popup.service';

@NgModule({
  declarations: [ConfirmationPopupComponent],
  imports: [CommonModule, ModalDialogModule],
  providers: [ConfirmationPopUpService],
  entryComponents: [ConfirmationPopupComponent],
  exports: [ConfirmationPopupComponent],
})
export class ConfirmationPopupModule {}
