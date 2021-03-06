import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';

const errorPagesRoutes: Routes = [
  { path: '401', component: NotAuthorizedComponent },
  { path: '403', component: ForbiddenComponent },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '404' }
];

@NgModule({
  imports: [
    RouterModule.forChild(errorPagesRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class ErrorPagesRoutingModule {}
