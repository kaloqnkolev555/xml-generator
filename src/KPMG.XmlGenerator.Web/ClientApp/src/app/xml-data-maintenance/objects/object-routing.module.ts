import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ObjectMaintenanceComponent } from './containers';
import { ObjectsResolver } from './resolvers/objects-resolver.service';
import { UpdateObjectResolver } from './resolvers/update-object-resolver.service';
import { StepsRedirectGuard } from './guards/steps-redirect-guard.service';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ObjectMaintenanceComponent,
    resolve: {
      objects: ObjectsResolver,
    },
  },
  {
    path: 'create',
    loadChildren: () => import('./create-object/create-object.module').then(m => m.CreateObjectModule),
  },
  {
    path: 'edit/:objectId',
    loadChildren: () => import('./update-object/update-object.module').then(m => m.UpdateObjectModule),
    canActivate: [UpdateObjectResolver],
  },
  {
    path: 'delete',
    loadChildren: () => import('./delete-object/delete-object.module').then(m => m.DeleteObjectModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ObjectRoutingModule {}
