import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { EditVariantComponent } from './containers/edit-variant/edit-variant.component';
import { VariantsResolver } from '../resolvers/variants-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: EditVariantComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      variants: VariantsResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditVariantRoutingModule {}

