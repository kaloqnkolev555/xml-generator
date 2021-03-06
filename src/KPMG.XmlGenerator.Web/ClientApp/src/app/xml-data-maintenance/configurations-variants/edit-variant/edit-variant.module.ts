import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditVariantComponent } from './containers/edit-variant/edit-variant.component';
import { EditVariantRoutingModule } from './edit-variant-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { SecondaryHeaderModule } from '../../../common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [EditVariantComponent],
  imports: [CommonModule, SharedModule, SecondaryHeaderModule, EditVariantRoutingModule],
})
export class EditVariantModule {}
