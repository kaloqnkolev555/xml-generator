import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { FormComponent } from './form.component';

@NgModule({
  declarations: [FormComponent],
  imports: [
    SharedModule
  ]
})
export class FormModule { }
