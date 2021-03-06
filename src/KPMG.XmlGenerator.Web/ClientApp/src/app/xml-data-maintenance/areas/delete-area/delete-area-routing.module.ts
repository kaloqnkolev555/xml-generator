import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { DeleteAreaComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';
import { IArea } from '@app/common/interfaces';
import { AreasResolver } from '../resolvers/areas-resolver.service';

export interface IMapObjectToAreasComponentResolve {
  areas: IArea[];
}
const routes: Routes = [
  {
    path: '',
    component: DeleteAreaComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      areas: AreasResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeleteAreaRoutingModule {}
