import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER, ErrorHandler } from '@angular/core';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { FormModule } from './form/form.module';
import { AppRoutingModule } from './app-routing.module';
import { AdminModule } from './admin/admin.module';
import { ErrorPagesModule } from './error-pages/error-pages.module';
import { UserDetailsModule } from './user-details/user-details.module';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { ModalModule } from 'ngx-bootstrap';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { DEFAULT_LANG } from './core/nav-menu/nav-menu.component';
import { take } from 'rxjs/operators';
import { APP_CONFIG } from './common/base-url/app-settings.token';
import { environment } from './../environments/environment';
import { ServerErrorInterceptor } from './common/interceptors/server-error.interceptor';
import { GlobalErrorHandler } from './common/services/global-error-handler.service';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    FormModule,
    AdminModule,
    UserDetailsModule,
    ModalDialogModule.forRoot(),
    ModalModule.forRoot(),
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    ErrorPagesModule, // should be the last module because consists the routing wildcard
  ],
  providers: [
    {
      provide: ErrorHandler, 
      useClass: GlobalErrorHandler
    },
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFactory,
      deps: [TranslateService, LocalStorage],
      multi: true,
    },
    {
      provide: APP_CONFIG,
      useValue: environment,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

export function appInitializerFactory(
  translateService: TranslateService,
  localStorage: LocalStorage
): () => Promise<{}> {
  return () =>
    new Promise(resolve => {
      localStorage
        .getItem<string>('lang')
        .pipe(take(1))
        .subscribe((lang: string) => {
          const langToSet = DEFAULT_LANG;

          translateService.setDefaultLang(DEFAULT_LANG);
          translateService.use(langToSet);
          resolve(null);
        });
    });
}
