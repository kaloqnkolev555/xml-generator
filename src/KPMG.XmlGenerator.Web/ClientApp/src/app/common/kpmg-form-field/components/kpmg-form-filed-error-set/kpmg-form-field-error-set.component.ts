import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

export interface IFormFieldErrorSet {
  type: string;
  message: string;
}

@Component({
  selector: 'app-kpmg-form-field-error-set',
  templateUrl: './kpmg-form-field-error-set.component.html',
  styleUrls: ['./kpmg-form-field-error-set.component.scss'],
})
export class KpmgFormFieldErrorSetComponent {
  @Input() public control: FormControl;
  @Input() public errorsSet: IFormFieldErrorSet[] = [];
}
