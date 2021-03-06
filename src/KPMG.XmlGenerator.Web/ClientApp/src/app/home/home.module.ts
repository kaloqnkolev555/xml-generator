import { NgModule } from '@angular/core';

import { HomeComponent } from './home.component';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { ModalModule } from 'ngx-bootstrap';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    SharedModule,
    SecondaryHeaderModule,
    ModalModule.forRoot()
  ]
})
export class HomeModule { }
