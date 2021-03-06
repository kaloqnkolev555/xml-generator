import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';
import { VariantObjectMappingComponent } from './containers';
import { VariantsResolver } from '../resolvers/variants-resolver.service';
import { ObjectsResolver } from '../../../xml-data-maintenance/objects/resolvers/objects-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: VariantObjectMappingComponent,
    resolve: {
      objects: ObjectsResolver,
      variants: VariantsResolver,
    },
    canDeactivate: [CanDeactivateFormChangesGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VariantObjectMappingRoutingModule {}
