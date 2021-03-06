import { Component, Input, AfterViewInit, ContentChild } from '@angular/core';
import { FormControlName, FormControl } from '@angular/forms';
import { IFormFieldErrorSet } from '@app/common/kpmg-form-field/components';

@Component({
  selector: 'app-ng-select-wrapper',
  templateUrl: './ng-select-wrapper.component.html',
  styleUrls: ['./ng-select-wrapper.component.scss'],
})
export class NgSelectWrapperComponent implements AfterViewInit {
  @Input() public errorsSet: IFormFieldErrorSet[] = [];
  @Input() public controlRef: FormControl;

  public control: FormControl;

  @ContentChild(FormControlName, { static: true })
  public formControlNameRef: FormControlName;

  ngAfterViewInit() {
    setTimeout(() => {
      if (this.formControlNameRef) this.control = this.formControlNameRef.control;
      if (this.controlRef) this.control = this.controlRef;
    }, 0);
  }
}
