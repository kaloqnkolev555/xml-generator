import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateVariantComponent } from './containers';
import { CreateVariantRoutingModule } from '@app/xml-data-maintenance/configurations-variants/create-variant/create-variant-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [CreateVariantComponent],
  imports: [CommonModule, SharedModule, CreateVariantRoutingModule, SecondaryHeaderModule],
})
export class CreateVariantModule {}
