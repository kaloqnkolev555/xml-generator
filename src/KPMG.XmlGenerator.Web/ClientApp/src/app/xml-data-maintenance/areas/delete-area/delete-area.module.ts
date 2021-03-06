import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteAreaComponent } from './containers';
import { DeleteAreaRoutingModule } from '@app/xml-data-maintenance/areas/delete-area/delete-area-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { XmlButtonModule } from '@app/xml-data-maintenance/xml-button/xml-button.module';
import { SearchSelectModule } from '@app/common/search-select/search-select.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [DeleteAreaComponent],

  imports: [
    CommonModule,
    SharedModule,
    DeleteAreaRoutingModule,
    SecondaryHeaderModule,
    XmlButtonModule,
    SearchSelectModule,
  ],
})
export class DeleteAreaModule {}
