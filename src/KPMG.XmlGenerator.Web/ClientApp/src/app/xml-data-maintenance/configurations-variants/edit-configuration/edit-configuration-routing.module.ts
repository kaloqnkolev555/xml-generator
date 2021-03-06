import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { EditConfigurationComponent } from './containers/edit-configuration/edit-configuration.component';
import { ConfigurationsResolver } from '../resolvers/configurations-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: EditConfigurationComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      configurations: ConfigurationsResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditConfigurationRoutingModule {}
