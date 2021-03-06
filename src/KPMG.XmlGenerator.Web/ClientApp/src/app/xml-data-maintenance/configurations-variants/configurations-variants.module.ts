import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '@app/core/core.module';
import { ConfigurationsVariantsRoutingModule } from './configurations-variants-routing.module';
import { ConfigurationsVariantsMaintenanceComponent } from './containers';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [ConfigurationsVariantsMaintenanceComponent],
  imports: [CommonModule, CoreModule, SharedModule, ConfigurationsVariantsRoutingModule, SecondaryHeaderModule],
})
export class ConfigurationsVariantsModule {}
