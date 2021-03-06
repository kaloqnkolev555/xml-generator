import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AreaMaintenanceComponent } from './containers';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: AreaMaintenanceComponent,
  },
  {
    path: 'create-new',
    loadChildren: () => import('./create-area/create-area.module').then(m => m.CreateAreaModule),
  },
  {
    path: 'edit-area',
    loadChildren: () => import('./edit-area/edit-area.module').then(m => m.EditAreaModule),
  },
  {
    path: 'map-objects-to-area',
    loadChildren: () => import('./map-objects-to-area/map-objects-to-area.module').then(m => m.MapObjectsToAreaModule),
  },
  {
    path: 'delete-area',
    loadChildren: () => import('./delete-area/delete-area.module').then(m => m.DeleteAreaModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AreasRoutingModule {}
