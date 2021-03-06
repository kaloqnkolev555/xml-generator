import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateAreaComponent } from './containers';
import { CreateAreaRoutingModule } from '@app/xml-data-maintenance/areas/create-area/create-area-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [CreateAreaComponent],
  imports: [
    CommonModule,
    SharedModule,
    CreateAreaRoutingModule,
    SecondaryHeaderModule,
  ],
})
export class CreateAreaModule {}
