import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { XmlDataMaintenanceComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    component: XmlDataMaintenanceComponent,
  },
  {
    path: 'objects',
    loadChildren: () => import('./objects/objects.module').then(m => m.ObjectsModule),
  },
  {
    path: 'areas',
    loadChildren: () => import('./areas/areas.module').then(m => m.AreasModule),
  },
  {
    path: 'configurations-variants',
    loadChildren: () =>
      import('./configurations-variants/configurations-variants.module').then(m => m.ConfigurationsVariantsModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class XMLDataMaintenanceRoutingModule {}
