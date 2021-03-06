import { AbstractControl } from '@angular/forms';

export const existingPropertyValidator = function<T>(objects: T[], property: keyof T) {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const controlValue = control.value;
    const isThere = objects.some(object => {
      const objectValue = object[property];
      if (typeof objectValue === 'string' && typeof controlValue === 'string') {
        return objectValue.toLocaleLowerCase() === controlValue.toLocaleLowerCase();
      }

      return objectValue === controlValue;
    });
    return isThere ? { [`existing-${property}`]: { value: controlValue } } : null;
  };
};
