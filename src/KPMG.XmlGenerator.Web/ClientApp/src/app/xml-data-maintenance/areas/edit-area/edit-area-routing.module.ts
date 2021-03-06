import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { EditAreaComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { AreasResolver } from '../resolvers/areas-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: EditAreaComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      areas: AreasResolver,
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditAreaRoutingModule {}

