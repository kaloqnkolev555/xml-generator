import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { ServerValidationResult } from '../../common/interfaces/server-validation-result.interface';
import { ObjectsService } from './objects.service';

export class ObjectNameValidators {
  static createAsyncValidator(objectsService: ObjectsService, object_id?: number): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors> => {
      return objectsService.validateObjectName(control.value, object_id).pipe(
        take(1),
        map<ServerValidationResult, ValidationErrors>(result =>
          !!result && !result.isValidationSuccessful ? { objectNameErrors: result.validationErrors } : null
        )
      );
    };
  }
}
