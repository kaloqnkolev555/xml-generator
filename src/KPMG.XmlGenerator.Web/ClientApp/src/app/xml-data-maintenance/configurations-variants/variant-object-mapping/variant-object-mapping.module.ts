import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VariantObjectMappingComponent } from './containers';
import { SharedModule } from '../../../shared/shared.module';
import { VariantObjectMappingRoutingModule } from './variant-object-mapping-routing.module';
import { SecondaryHeaderModule } from '../../../common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [VariantObjectMappingComponent],
  imports: [CommonModule, SharedModule, SecondaryHeaderModule, VariantObjectMappingRoutingModule],
})
export class VariantObjectMappingModule {}
