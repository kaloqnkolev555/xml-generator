import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObjectMaintenanceComponent } from './containers';
import { ObjectRoutingModule } from './object-routing.module';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { ResetServiceGuard } from './guards/reset-service-guard.service';
import { StepsRedirectGuard } from './guards/steps-redirect-guard.service';
import { BREAD_CRUMBS_BUILDER, breadCrumbsBuilder } from './objects-shared-module/resources/bread-crumbs-builder';
import { ModalModule } from 'ngx-bootstrap';
import { UpdateObjectResolver } from './resolvers/update-object-resolver.service';
import { DeleteObjectModule } from './delete-object/delete-object.module';

@NgModule({
  declarations: [ObjectMaintenanceComponent],
  imports: [
    CommonModule,
    SharedModule,
    SecondaryHeaderModule,
    ObjectRoutingModule,
    ModalModule.forRoot(),
    DeleteObjectModule,
  ],
  providers: [
    UpdateObjectResolver,
    ResetServiceGuard,
    StepsRedirectGuard,
    { provide: BREAD_CRUMBS_BUILDER, useValue: breadCrumbsBuilder },
  ],
})
export class ObjectsModule {}
