import { NgModule, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecondaryHeaderComponent } from './';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [SecondaryHeaderComponent],
  imports: [RouterModule, CommonModule, forwardRef(() => SharedModule)],
  exports: [SecondaryHeaderComponent],
})
export class SecondaryHeaderModule {}
