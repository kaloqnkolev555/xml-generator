import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { ErrorPagesRoutingModule } from './error-pages-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [
    NotAuthorizedComponent,
    NotFoundComponent,
    ForbiddenComponent
  ],
  imports: [
    CommonModule,
    ErrorPagesRoutingModule,
    SharedModule
  ]
})
export class ErrorPagesModule { }
