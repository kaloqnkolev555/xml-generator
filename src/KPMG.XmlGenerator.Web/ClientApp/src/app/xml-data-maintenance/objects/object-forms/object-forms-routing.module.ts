import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  CgMetaObjectFormComponent,
  CgMetaTechnicalSettingFormComponent,
  CgMetaAreaToObjectComponent,
  CgMetaConstraintComponent,
  CgMetaHconstraintToAreaComponent,
  CgMetaVariantsToObjectComponent,
  ObjectOverviewComponent,
} from './components';
import { CGMetaGroupResolver } from '../resolvers/cg-meta-group-resolver.service';
import { CGMetaTableResolver } from '../resolvers/cg-meta-table-resolver.service';
import { ObjectsResolver } from '../resolvers/objects-resolver.service';
import { CGMetaHelperNamesResolver } from '../resolvers/helper-names-resolver.service';
import { CGMetaExtractionLogicResolver } from '../resolvers/extraction-logic-resolver.service';
import { AreasResolver } from '@app/xml-data-maintenance/areas/resolvers/areas-resolver.service';
import { CGMetaTechnicalSettingsNrObjectResolver } from '../resolvers/technical-settings-nr-object-resolver.service';
import { CGMetaTechnicalSettingsNrFieldResolver } from '../resolvers/technical-settings-nr-field-resolver.service';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';
import { StepsRedirectGuard } from '../guards/steps-redirect-guard.service';
import { CreateObjectSteps } from '../objects-shared-module/resources';
import { CgMetaColumnComponent } from './components/cg-meta-column/cg-meta-column.component';
import { CGMetaConstraintValueResolver } from '../resolvers/constraint-value-resolver.service';
import { CGMetaConstraintOptionResolver } from '../resolvers/constraint-option-resolver.service';
import { CGMetaVariantsWithConfigurationsResolver } from '../resolvers/variants-with-configurations-resolver.service';
import { DD03LColumnResolver } from './resolvers/dd03l-column-resolver.service';
import { GetAreasForRefTableResolver } from './resolvers/get-areas-for-ref-table-resolver.service';

const routes: Routes = [
  {
    path: '',
    redirectTo: CreateObjectSteps.CG_META_OBJECT,
  },
  {
    path: CreateObjectSteps.CG_META_OBJECT,
    component: CgMetaObjectFormComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    data: {
      step: CreateObjectSteps.CG_META_OBJECT,
    },
    resolve: {
      groups: CGMetaGroupResolver,
      tables: CGMetaTableResolver,
      objects: ObjectsResolver,
    },
  },
  {
    path: CreateObjectSteps.CG_META_TECHNICAL_SETTING,
    component: CgMetaTechnicalSettingFormComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    data: {
      step: CreateObjectSteps.CG_META_TECHNICAL_SETTING,
    },
    resolve: {
      helperNames: CGMetaHelperNamesResolver,
      extractionLogic: CGMetaExtractionLogicResolver,
      tables: CGMetaTableResolver,
      nrObject: CGMetaTechnicalSettingsNrObjectResolver,
      nrField: CGMetaTechnicalSettingsNrFieldResolver,
    },
  },
  {
    path: CreateObjectSteps.CG_AREA_MAPPING,
    component: CgMetaAreaToObjectComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    resolve: {
      areas: AreasResolver,
    },
    data: {
      step: CreateObjectSteps.CG_AREA_MAPPING,
    },
  },
  {
    path: CreateObjectSteps.CG_COLUMN_MAPPING,
    component: CgMetaColumnComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    resolve: {
      dd03lColumns: DD03LColumnResolver,
      refAreas: GetAreasForRefTableResolver,
    },
  },
  {
    path: CreateObjectSteps.CG_CONSTRAINT,
    component: CgMetaConstraintComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    resolve: {
      constraintValue: CGMetaConstraintValueResolver,
      constraintOption: CGMetaConstraintOptionResolver,
    },
    data: {
      step: CreateObjectSteps.CG_CONSTRAINT,
    },
  },
  {
    path: CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA,
    component: CgMetaHconstraintToAreaComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    data: {
      step: CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA,
    },
  },
  {
    path: CreateObjectSteps.CG_VARIANT_MAPPING,
    component: CgMetaVariantsToObjectComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    canActivate: [StepsRedirectGuard],
    resolve: {
      variants: CGMetaVariantsWithConfigurationsResolver,
    },
    data: {
      step: CreateObjectSteps.CG_VARIANT_MAPPING,
    },
  },
  {
    path: CreateObjectSteps.OBJECT_OVERVIEW,
    component: ObjectOverviewComponent,
    //canDeactivate: [CanDeactivateFormChangesGuard], not needed - no changes possible here
    canActivate: [StepsRedirectGuard],
    data: {
      step: CreateObjectSteps.OBJECT_OVERVIEW,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ObjectFormsRoutingModule {}
