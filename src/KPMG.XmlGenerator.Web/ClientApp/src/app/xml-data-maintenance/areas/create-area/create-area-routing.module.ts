import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CreateAreaComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';
import { IArea } from '@app/common/interfaces';
import { ObjectsResolver } from '../../../xml-data-maintenance/objects/resolvers/objects-resolver.service';
import { AreasResolver } from '../resolvers/areas-resolver.service';

export interface IMapObjectToAreasComponentResolve {
  areas: IArea[];
}
const routes: Routes = [
  {
    path: '',
    component: CreateAreaComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      // objects: ObjectsResolver,
      // areas: AreasResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateAreaRoutingModule {}
