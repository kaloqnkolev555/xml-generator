import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) { }

  handleError(error) {
    const toastr = this.injector.get(ToastrService);
    
    if (error instanceof HttpErrorResponse) {
      return toastr.error(error.error.error, 'Error!');
    }

    if (error.skipError) return;

    throw error;
  }
}
