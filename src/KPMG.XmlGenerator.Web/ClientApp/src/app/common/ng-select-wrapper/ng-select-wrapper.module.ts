import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectWrapperComponent } from './components';
import { KpmgFormFieldModule } from '../kpmg-form-field/kpmg-form-field.module';

@NgModule({
  declarations: [NgSelectWrapperComponent],
  imports: [CommonModule, KpmgFormFieldModule],
  exports: [NgSelectWrapperComponent],
})
export class NgSelectWrapperModule {}
