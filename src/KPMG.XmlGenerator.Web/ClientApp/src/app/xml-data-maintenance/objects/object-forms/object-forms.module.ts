import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  CgMetaObjectFormComponent,
  CgMetaTechnicalSettingFormComponent,
  CgMetaAreaToObjectComponent,
  CgMetaConstraintComponent,
  CgMetaHconstraintToAreaComponent,
  HardConstraintQueryEditorComponent,
  ObjectOverviewComponent,
  ObjectOverviewObjectInfoComponent,
  ObjectOverviewTechnicalSettingComponent,
  CgMetaVariantsToObjectComponent,
  CgMetaColumnComponent,
  CgMetaColumnElementComponent,
} from './components';
import { SharedModule } from '@app/shared/shared.module';
import { ObjectFormsRoutingModule } from './object-forms-routing.module';
import { DD03LColumnResolver } from './resolvers/dd03l-column-resolver.service';
import { GetAreasForRefTableResolver } from './resolvers/get-areas-for-ref-table-resolver.service';
import { keyColumnValidator, KEY_COLUMN_VALIDATOR } from './validations';

@NgModule({
  declarations: [
    CgMetaObjectFormComponent,
    CgMetaTechnicalSettingFormComponent,
    CgMetaAreaToObjectComponent,
    ObjectOverviewComponent,
    ObjectOverviewObjectInfoComponent,
    ObjectOverviewTechnicalSettingComponent,
    CgMetaConstraintComponent,
    HardConstraintQueryEditorComponent,
    CgMetaHconstraintToAreaComponent,
    CgMetaVariantsToObjectComponent,
    CgMetaColumnComponent,
    CgMetaColumnElementComponent,
  ],
  providers: [
    DD03LColumnResolver,
    GetAreasForRefTableResolver,
    { provide: KEY_COLUMN_VALIDATOR, useValue: keyColumnValidator },
  ],
  imports: [CommonModule, ObjectFormsRoutingModule, SharedModule],
})
export class ObjectFormsModule {}
