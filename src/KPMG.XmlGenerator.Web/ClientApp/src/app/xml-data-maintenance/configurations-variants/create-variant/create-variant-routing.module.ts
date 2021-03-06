import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CreateVariantComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { ObjectsResolver } from '../../../xml-data-maintenance/objects/resolvers/objects-resolver.service';
import { VariantsResolver } from '../resolvers/variants-resolver.service';
import { IVariants } from '../../../common/interfaces/variants.interface';

export interface IMapObjectToVariantComponentResolve {
  variants: IVariants[];
}

const routes: Routes = [
  {
    path: '',
    component: CreateVariantComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      objects: ObjectsResolver,
      variants: VariantsResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateVariantRoutingModule {}
