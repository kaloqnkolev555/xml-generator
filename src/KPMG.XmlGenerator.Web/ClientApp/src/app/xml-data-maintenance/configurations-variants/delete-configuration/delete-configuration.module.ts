import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteConfigurationComponent } from './containers/delete-configuration/delete-configuration.component';
import { DeleteConfigurationRoutingModule } from './delete-configuration-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { SecondaryHeaderModule } from '../../../common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [DeleteConfigurationComponent],
  imports: [CommonModule, SharedModule, SecondaryHeaderModule, DeleteConfigurationRoutingModule],
})
export class DeleteConfigurationModule {}
