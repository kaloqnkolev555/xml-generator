import { AbstractControl } from '@angular/forms';

export const greaterValue = function(control1: AbstractControl) {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const controlValue = control.value;
    if (controlValue >= control1.value) {
      if (controlValue !== 0) {
        return { validValue: { value: controlValue } };
      }
      return null;
    }
    return null;
  };
};
