import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { SecondaryHeaderModule } from '../../../common/secondary-header/secondary-header.module';
// import { ConfigurationVariantsMappingComponent } from './containers';
import { ConfigurationVariantsMappingRouting } from './configuration-variants-mapping-routing.module';

@NgModule({
  declarations: [
    // ConfigurationVariantsMappingComponent,
  ],
  imports: [
    CommonModule,
    ConfigurationVariantsMappingRouting,
    SharedModule,
    SecondaryHeaderModule,
  ]
})
export class ConfigurationVariantsMappingModule { }
