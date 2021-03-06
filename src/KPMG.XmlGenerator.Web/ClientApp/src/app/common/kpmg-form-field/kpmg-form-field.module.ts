import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { KpmgFormFieldComponent, KpmgFormFieldErrorComponent, KpmgFormFieldErrorSetComponent } from './components';

@NgModule({
  declarations: [KpmgFormFieldComponent, KpmgFormFieldErrorComponent, KpmgFormFieldErrorSetComponent],
  imports: [CommonModule, FormsModule],
  exports: [KpmgFormFieldComponent, KpmgFormFieldErrorComponent, KpmgFormFieldErrorSetComponent],
})
export class KpmgFormFieldModule {}
