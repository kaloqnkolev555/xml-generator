import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CanDeactivateFormChangesGuard } from '../../../shared/services/can-deactivate-form-changes.service';
import { VariantsResolver } from '../resolvers/variants-resolver.service';
// import { ConfigurationVariantsMappingComponent } from './containers';
import { ConfigurationsResolver } from '../resolvers/configurations-resolver.service';

const routes: Routes = [
  {
    path: '',
    // component: ConfigurationVariantsMappingComponent,
    canDeactivate: [CanDeactivateFormChangesGuard],
    resolve: {
      variants: VariantsResolver,
      configurations: ConfigurationsResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConfigurationVariantsMappingRouting {}
