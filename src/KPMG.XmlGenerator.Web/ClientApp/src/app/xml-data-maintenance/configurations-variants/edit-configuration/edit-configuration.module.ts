import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditConfigurationComponent } from './containers/edit-configuration/edit-configuration.component';
import { EditConfigurationRoutingModule } from './edit-configuration-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { SecondaryHeaderModule } from '../../../common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [EditConfigurationComponent],
  imports: [CommonModule, SharedModule, SecondaryHeaderModule, EditConfigurationRoutingModule],
})
export class EditConfigurationModule {}
