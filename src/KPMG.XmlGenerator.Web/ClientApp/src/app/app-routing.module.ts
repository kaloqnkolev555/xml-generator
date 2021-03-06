import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { AdminGuard } from './admin/admin.guard';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserDetailsGuard } from './user-details/user-details.guard';
import { FormComponent } from './form/form.component';
import { LocalStorageGuard } from './local-storage.guard';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  {
    path: 'user-details',
    component: UserDetailsComponent,
    // canActivate: [UserDetailsGuard],
  },
  {
    path: 'admin',
    component: AdminComponent,
    // canActivate: [AdminGuard],
  },
  {
    path: 'form',
    component: FormComponent,
  },
  {
    path: 'xml-data-maintenance',
    loadChildren: () =>
      import('./xml-data-maintenance/xml-data-maintenance.module').then(m => m.XmlDataMaintenanceModule),
    // canActivate: [LocalStorageGuard],
    // canActivateChild: [LocalStorageGuard],
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, {
      useHash: true,
      scrollPositionRestoration: 'enabled',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
