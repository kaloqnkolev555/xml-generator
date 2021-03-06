import { Component, OnInit, Input, Output, EventEmitter, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

export interface IToggleButtonOption {
  [key: string]: any;
  isActive?: boolean;
}

@Component({
  selector: 'app-toggle-button',
  templateUrl: './toggle-button.component.html',
  styleUrls: ['./toggle-button.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ToggleButtonComponent),
      multi: true,
    },
  ],
})
export class ToggleButtonComponent<T extends { isSelected?: boolean }> implements OnInit, ControlValueAccessor {
  private _isDisabled = false;

  @Input() public options: T[] = [];
  @Input() public bindValue: keyof T;
  @Input() public bindLabel: keyof T;

  @Output() selected = new EventEmitter<T>();

  public selectedValue: any;

  ngOnInit() {
    const selectedOption = this.options.find(option => option.isSelected);
    if (selectedOption) this.selectedValue = this.optionBindingValue(selectedOption);
    if (!selectedOption) this.selectedValue = this.optionBindingValue(this.options[0]);
  }

  propagateChange = (_: any) => {
    /* */
  };

  public optionBindingValue(option: T) {
    if (option[this.bindValue] === undefined) return option[this.bindLabel];

    return option[this.bindValue];
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  public get disabled() {
    return this._isDisabled;
  }

  public set disabled(value: boolean) {
    this._isDisabled = value;
  }

  setDisabledState(state: boolean) {
    this.disabled = state;
  }

  registerOnTouched() {
    /* */
  }

  writeValue(value: any) {
    if (value !== undefined) {
      this.selectedValue = value;
    }
  }

  public select(option: T) {
    if (this.disabled) return false;

    this.selectedValue = this.optionBindingValue(option);
    this.selected.emit(this.selectedValue);
    this.propagateChange(this.selectedValue);
  }
}
