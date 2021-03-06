import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateConfigurationComponent } from './containers';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { CreateConfigurationRoutingModule } from './create-configuration-routing.module';

@NgModule({
  declarations: [CreateConfigurationComponent],
  imports: [CommonModule, CreateConfigurationRoutingModule, SharedModule, SecondaryHeaderModule],
})
export class CreateConfigurationModule {}
