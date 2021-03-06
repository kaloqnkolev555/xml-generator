import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@app/shared/shared.module';
import { CreateObjectRoutingModule } from './create-object-routing.module';
import { ObjectsSharedModule } from '../objects-shared-module/objects-shared.module';
import { CreateObjectComponent } from './containers';

@NgModule({
  declarations: [CreateObjectComponent],
  imports: [CommonModule, CreateObjectRoutingModule, SharedModule, ObjectsSharedModule],
})
export class CreateObjectModule {}
