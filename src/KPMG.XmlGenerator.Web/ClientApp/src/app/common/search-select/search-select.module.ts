import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchSelectComponent, SearchSelectOptionComponent } from './components';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { KpmgFormFieldModule } from '../kpmg-form-field/kpmg-form-field.module';

@NgModule({
  declarations: [SearchSelectComponent, SearchSelectOptionComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, KpmgFormFieldModule],
  exports: [SearchSelectComponent, SearchSelectOptionComponent],
})
export class SearchSelectModule {}
