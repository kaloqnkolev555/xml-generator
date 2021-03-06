import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@app/shared/shared.module';
import { ObjectsSharedModule } from '../objects-shared-module/objects-shared.module';
import { UpdateObjectRoutingModule } from './update-object-routing.module';
import { UpdateObjectComponent } from './containers';

@NgModule({
  declarations: [UpdateObjectComponent],
  imports: [CommonModule, SharedModule, UpdateObjectRoutingModule, ObjectsSharedModule],
})
export class UpdateObjectModule {}
