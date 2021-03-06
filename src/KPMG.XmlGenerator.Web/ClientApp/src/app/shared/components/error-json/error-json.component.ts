import { Component, Input, HostBinding } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-error-json',
  templateUrl: './error-json.component.html',
  styleUrls: ['./error-json.component.scss'],
})
export class ErrorJsonComponent {
  public errorLines: ErrorLine[] = [];

  @Input()
  public set jsonMessage(value: any) {
    const errObject = this.convertToObject(value);
    this.errorLines = Object.keys(errObject).map(k => <ErrorLine>{ key: k, value: errObject[k] });
  }

  public get jsonMessage(): any {
    return this.errorLines;
  }

  private isList(value: any): boolean {
    if (!!value) {
      const jsonMessageType = Object.prototype.toString.call(value);
      if (jsonMessageType === '[object Object]' || jsonMessageType === '[object Array]') {
        return true;
      }
      const [parseError, parseResult] = this.safeJsonParse(value);
      return !parseError;
    }
    return false;
  }

  public convertToObject(value: any): any {
    if (!value) {
      return { "Message": "No error to display." };
    }
    if (typeof value === 'string') {
      const [parseError, parseResult] = this.safeJsonParse(value);
      return !!parseError ? { "Error": value } : parseResult;
    } else if (this.isList(value)) {
      return value;
    } else {
      return { "Error": value };
    }
  }

  private safeJsonParse(str: string) {
    try {
      return [null, JSON.parse(str)];
    } catch (err) {
      return [err];
    }
  }
}

export interface ErrorLine {
  key: string;
  value: string;
}
