import { IFormFieldErrorSet } from '../kpmg-form-field/components';

export interface IErrorSet {
  [key: string]: IFormFieldErrorSet[];
}
