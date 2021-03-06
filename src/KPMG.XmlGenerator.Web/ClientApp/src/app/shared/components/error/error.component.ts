import { Component, Input, HostBinding } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss'],
})
export class ErrorComponent {
  @Input()
  public message: string;

  @Input()
  public control: AbstractControl;

  @HostBinding('class')
  public cssClass = 'alert alert-danger mt-1';

  @HostBinding('style.display')
  public get visibility() {
    return this.control && this.control.touched && this.control.invalid ? 'block' : 'none';
  }
}
