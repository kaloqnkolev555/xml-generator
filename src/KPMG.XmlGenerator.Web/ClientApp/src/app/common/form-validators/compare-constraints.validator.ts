import { FormArray } from '@angular/forms';
import { InjectionToken } from '@angular/core';
import * as _ from 'lodash';
import { IConstraint } from '../..//xml-data-maintenance/objects/interfaces/create-object-output.interface';

export type CompareConstraints = (formGroup: FormArray) => any;

export const compareConstraints = (formArray: FormArray) => {
  if (formArray.controls.length <= 1) return null;
  const constraints: IConstraint[] = formArray.controls.map(el => el.value);

  const uniqueControls = _.uniqWith(constraints, (a, b) => _.isEqual(a.constraintField, b.constraintField) &&
                                                            _.isEqual(a.constraintOption, b.constraintOption) && 
                                                            _.isEqual(a.constraintValue, b.constraintValue) &&
                                                            _.isEqual(a.area, b.area));
  const notUnique = formArray.controls.filter(control => !uniqueControls.find(el => el === control.value));

  if (uniqueControls.length !== formArray.controls.length) {
    return { diff: notUnique[0] };
  }

  return null;
};

export const COMPARE_CONSTRAINTS = new InjectionToken('compare.constraints');
