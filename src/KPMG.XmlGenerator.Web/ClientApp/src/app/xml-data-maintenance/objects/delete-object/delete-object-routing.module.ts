import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeleteObjectComponent } from './containers';
import { ObjectsResolver } from '../resolvers/objects-resolver.service';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';

const routes: Routes = [
  {
    path: '',
    component: DeleteObjectComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      objects: ObjectsResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DeleteObjectRoutingModule {}
