import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObjectLayoutComponent } from './components';
import { SharedModule } from '@app/shared/shared.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';
import { RouterModule } from '@angular/router';

const sharedDeclarations = [ObjectLayoutComponent];

@NgModule({
  declarations: [...sharedDeclarations],
  imports: [CommonModule, SharedModule, SecondaryHeaderModule, RouterModule],
  exports: [...sharedDeclarations],
})
export class ObjectsSharedModule {}
