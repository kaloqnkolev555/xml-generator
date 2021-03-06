import { AbstractControl, AsyncValidatorFn, ValidationErrors, ValidatorFn } from "@angular/forms";
import { BehaviorSubject, Observable } from "rxjs";
import { debounceTime, distinctUntilChanged, first, map, switchMap } from "rxjs/operators";
import { ISqlParseError } from "./interfaces/create-object-output.interface";
import { ObjectsService } from "./objects.service";

export class HardConstraintValidators {
  static createAsyncValidator(objectsService: ObjectsService): AsyncValidatorFn {
    const subject = new BehaviorSubject<string>('');
    const debouncedInput$ = subject.asObservable().pipe(
      distinctUntilChanged(),
      debounceTime(600),
      switchMap(value => objectsService.validateSqlWhereClause(value)
        .pipe(
          map<ISqlParseError[], ValidationErrors>(parseErrors => !!parseErrors && parseErrors.length ?
            { sqlParseErrors: parseErrors.map(parseError => `Line ${parseError.line - 1}, Column ${parseError.column}: ${parseError.message}`) } : null))
      ),
      first()
    );
    return (control: AbstractControl): Observable<ValidationErrors> => {
      subject.next(control.value);
      return debouncedInput$;
    };
  }
  static createValidator(maxlinelength: number = 70): ValidatorFn {
    return (control: AbstractControl) => {
      let validationErrors = [];
      const constraint = control.value;
      if (!constraint) {
        return null;
      }
      const allLines = constraint.split('\n').filter(l => !!l.trim());
      if (!/^\s+\(\s+/i.test(allLines[0])) {
        validationErrors.push('First line must start with \" ( \".');
      }
      if (!/\s+\)\s+$/i.test(allLines[allLines.length - 1])) {
        validationErrors.push('Last line must end with \" ) \".');
      }
      if (allLines.find(s => /[^\s\!]\!?\=|\S\!\=|\=\S/i.test(s))) {
        validationErrors.push('Equal \"=\" and Not Equal \"!=\" operators must be surrounded by spaces.');
      }
      if (allLines.length > 1) {
        let allButLastLine = allLines.slice(0, allLines.length - 1);
        if (allButLastLine.find(s => !/\s(AND|OR)(\s+\()*\s+$/i.test(s))) {
          validationErrors.push('All but last line must end with a logical operator: \" AND \" or \" OR \".');
        }
      }
      if (allLines.find(s => s.indexOf('<') > -1 || s.indexOf('>') > -1)) {
        validationErrors.push('Operators Greater Than \">\" and Less Than \"<\" are not allowed.');
      }
      if (maxlinelength > 0 && allLines.find(s => s.length > maxlinelength)) {
        validationErrors.push(`The maximum line length is ${maxlinelength} character${maxlinelength > 1 ? 's' : ''}, including spaces.`);
      }

      return validationErrors.length ? { validationErrors: validationErrors } : null;
    };
  }
}
