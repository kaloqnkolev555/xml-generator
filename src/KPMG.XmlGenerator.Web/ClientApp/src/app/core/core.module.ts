import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { SharedModule } from '@app/shared/shared.module';
import { FooterComponent } from './footer/footer.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoaderInterceptorService } from './loader/loader.interceptor.service';
import { LoaderComponent } from './loader/loader.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    FooterComponent,
    LoaderComponent
  ],
  imports: [
    SharedModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    NavMenuComponent,
    FooterComponent,
    LoaderComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptorService,
      multi: true
    }
  ]
})
export class CoreModule { }
