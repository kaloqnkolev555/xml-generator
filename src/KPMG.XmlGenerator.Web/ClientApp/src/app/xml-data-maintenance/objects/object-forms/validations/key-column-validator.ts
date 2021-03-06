import { FormControl } from '@angular/forms';
import { InjectionToken } from '@angular/core';

export type KeyColumnValidator = (control: FormControl) => {
  'atLeastOneKeyColumn': boolean;
} | null;

export const keyColumnValidator: KeyColumnValidator = (control: FormControl) => {
  if (!Array.isArray(control.value)) {
    return { 'atLeastOneKeyColumn': true }
  }

  const isThereKeyColumn = control.value.find(el => el.keyFlag);
  if (isThereKeyColumn) return null;

  return { 'atLeastOneKeyColumn': true }
};

export const KEY_COLUMN_VALIDATOR = new InjectionToken('key.column.validator');