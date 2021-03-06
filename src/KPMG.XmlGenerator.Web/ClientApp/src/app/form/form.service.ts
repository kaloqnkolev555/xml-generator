import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Item } from './form.models';

@Injectable({
  providedIn: 'root',
})
export class FormService {
  constructor(private http: HttpClient) {}

  public getData(): Observable<Item[]> {
    // This is done to demonstrate how to make a get request. Normally in a real-world application
    // you will be getting your data from the server and not static json file, but the process is just the same.
    return this.http.get<Item[]>(this.getBaseUrl() + 'assets/demo/data.json').pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }

  private getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
  }
}
