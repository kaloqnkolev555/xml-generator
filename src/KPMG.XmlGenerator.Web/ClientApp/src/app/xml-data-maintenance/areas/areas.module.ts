import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AreaMaintenanceComponent } from './containers';
import { AreasRoutingModule } from './areas-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { CreateAreaModule } from '@app/xml-data-maintenance/areas/create-area/create-area.module';

import { EditAreaModule } from '@app/xml-data-maintenance/areas/edit-area/edit-area.module';
import { DeleteAreaModule } from '@app/xml-data-maintenance/areas/delete-area/delete-area.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [AreaMaintenanceComponent],

  imports: [
    CommonModule,
    SharedModule,
    AreasRoutingModule,
    SecondaryHeaderModule,
    CreateAreaModule,
    EditAreaModule,
    DeleteAreaModule,
  ],
})
export class AreasModule {}
