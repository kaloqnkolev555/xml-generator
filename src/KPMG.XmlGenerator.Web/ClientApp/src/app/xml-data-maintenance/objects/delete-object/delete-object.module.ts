import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@app/shared/shared.module';
import { DeleteObjectRoutingModule } from './delete-object-routing.module';
import { ObjectsSharedModule } from '../objects-shared-module/objects-shared.module';
import { DeleteObjectComponent } from './containers';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [DeleteObjectComponent],
  imports: [CommonModule, DeleteObjectRoutingModule, SecondaryHeaderModule, SharedModule, ObjectsSharedModule],
})
export class DeleteObjectModule {}
