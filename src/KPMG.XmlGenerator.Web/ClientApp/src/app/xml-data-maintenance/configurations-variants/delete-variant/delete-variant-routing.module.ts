import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { DeleteVariantComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';
import { VariantsResolver } from '../resolvers/variants-resolver.service';
import { IVariants } from '../../../common/interfaces/variants.interface';

export interface IMapObjectToVariantComponentResolve {
  variants: IVariants[];
}
const routes: Routes = [
  {
    path: '',
    component: DeleteVariantComponent,
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
export class DeleteVariantRoutingModule {}
