import { FormArray } from '@angular/forms';
import { InjectionToken } from '@angular/core';
import * as _ from 'lodash';
import { IHardCodedConstraint } from '../..//xml-data-maintenance/objects/interfaces/create-object-output.interface';

export type CompareHConstraints = (formGroup: FormArray) => any;

export const compareHConstraints = (formArray: FormArray) => {
  if (formArray.controls.length <= 1) return null;
  const hardCodedconstraints: IHardCodedConstraint[] = formArray.controls.map(el => el.value);

  const uniqueControls = _.uniqWith(hardCodedconstraints, (a, b) => _.isEqual(a.area, b.area));
  const notUnique = formArray.controls.filter(control => !uniqueControls.find(el => el === control.value));

  if (uniqueControls.length !== formArray.controls.length) {
    return { diff: notUnique[0] };
  }

  return null;
};

export const COMPARE_H_CONSTRAINTS = new InjectionToken('compare.hconstraints');
