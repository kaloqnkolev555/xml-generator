import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteVariantComponent } from './containers';
import { DeleteVariantRoutingModule } from '@app/xml-data-maintenance/configurations-variants/delete-variant/delete-variant-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { XmlButtonModule } from '@app/xml-data-maintenance/xml-button/xml-button.module';
import { SearchSelectModule } from '@app/common/search-select/search-select.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [DeleteVariantComponent],

  imports: [
    CommonModule,
    SharedModule,
    DeleteVariantRoutingModule,
    SecondaryHeaderModule,
    XmlButtonModule,
    SearchSelectModule,
  ],
})
export class DeleteVariantModule {}
