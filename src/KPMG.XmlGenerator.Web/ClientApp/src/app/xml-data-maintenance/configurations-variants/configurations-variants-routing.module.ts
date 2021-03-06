import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigurationsVariantsMaintenanceComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    component: ConfigurationsVariantsMaintenanceComponent,
  },
  {
    path: 'create-new',
    loadChildren: () => import('./create-variant/create-variant.module').then(m => m.CreateVariantModule),
  },
  {
    path: 'edit-variant',
    loadChildren: () => import('./edit-variant/edit-variant.module').then(m => m.EditVariantModule),
  },
  {
    path: 'variant-object-mapping',
    loadChildren: () =>
      import('./variant-object-mapping/variant-object-mapping.module').then(m => m.VariantObjectMappingModule),
  },
  {
    path: 'delete-variant',
    loadChildren: () => import('./delete-variant/delete-variant.module').then(m => m.DeleteVariantModule),
  },
  {
    path: 'create-configuration',
    loadChildren: () =>
      import('./create-configuration/create-configuration.module').then(m => m.CreateConfigurationModule),
  },
  {
    path: 'configuration-variant-mapping',
    loadChildren: () => import('./configuration-variants-mapping/configuration-variants-mapping.module').then(m => m.ConfigurationVariantsMappingModule),
  },
  {
    path: 'edit-configuration',
    loadChildren: () => import('./edit-configuration/edit-configuration.module').then(m => m.EditConfigurationModule),
  },
  {
    path: 'delete-configuration',
    loadChildren: () =>
      import('./delete-configuration/delete-configuration.module').then(m => m.DeleteConfigurationModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConfigurationsVariantsRoutingModule {}
