import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { XMLDataMaintenanceRoutingModule } from './xml-data-maintenance-routing.module';
import { XmlDataMaintenanceComponent } from './containers';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [XmlDataMaintenanceComponent],
  imports: [CommonModule, SharedModule, XMLDataMaintenanceRoutingModule, SecondaryHeaderModule],
})
export class XmlDataMaintenanceModule {}
