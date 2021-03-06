import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { InjectionToken } from '@angular/core';

export type MarkAllAsTouched = (formGroup: FormGroup | FormArray) => void;

export const markAllAsTouched: MarkAllAsTouched = formGroup => {
  Object.keys(formGroup.controls).forEach(field => {
    const control = formGroup.get(field);
    if (control instanceof FormControl && !control.disabled) {
      control.markAsTouched({ onlySelf: true });
    } else if (control instanceof FormGroup || control instanceof FormArray) {
      markAllAsTouched(control);
    }
  });
};

export const MARK_CONTROLS_AS_TOUCHED = new InjectionToken('mark.all.as.touched');
