import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CreateConfigurationComponent } from './containers';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { VariantsResolver } from '../resolvers/variants-resolver.service';
import { ConfigurationsResolver } from '../resolvers/configurations-resolver.service';

const routes: Routes = [
  {
    path: '',
    component: CreateConfigurationComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      variants: VariantsResolver,
      configurations: ConfigurationsResolver, //It's hack that I'm not proud of. It's back-end decision.
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateConfigurationRoutingModule {}
