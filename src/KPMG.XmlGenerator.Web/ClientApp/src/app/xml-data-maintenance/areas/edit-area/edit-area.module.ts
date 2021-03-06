
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditAreaComponent } from './containers';
import { EditAreaRoutingModule } from '@app/xml-data-maintenance/areas/edit-area/edit-area-routing.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { SearchSelectModule } from '@app/common/search-select/search-select.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [EditAreaComponent],
  imports: [
    CommonModule,
    SharedModule,
    EditAreaRoutingModule,
    SecondaryHeaderModule,
    SearchSelectModule,
  ],
})
export class EditAreaModule {}

