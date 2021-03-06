import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToggleButtonComponent } from './components/toggle-button/toggle-button.component';
import { XmlButtonModule } from '@app/xml-data-maintenance/xml-button/xml-button.module';

@NgModule({
  declarations: [ToggleButtonComponent],
  imports: [
    CommonModule,
    XmlButtonModule,
  ],
  exports: [ToggleButtonComponent],
})
export class ToggleButtonModule { }
