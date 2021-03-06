import { FormControlName } from '@angular/forms';
import { Directive, ElementRef, HostListener, Input, OnChanges, SimpleChanges, Optional, Self, Inject } from '@angular/core';

const INTEGER_FORMAT = '^[0-9]*$';
const NUMBER_FORMAT = '^\\d+\\,?\\d*$';

type InputFormat = '' | 'int' | 'number' | 'custom';

@Directive({
  selector: '[appInputMask]'
})
export class InputMaskDirective implements OnChanges {
  @Input('appInputMask')
  public type: InputFormat = '';

  @Input()
  public suffix = '';

  @Input()
  public customFormat = '';

  constructor(private element: ElementRef,
              @Optional() @Self() @Inject(FormControlName) private fcn: FormControlName) { }

  public ngOnChanges(changes: SimpleChanges) {
    if (changes.suffix && !changes.suffix.firstChange) {
      this.changeSuffix(changes.suffix.previousValue);
    }
  }

  @HostListener('keydown', ['$event'])
  public onKeyDown(args: KeyboardEvent) {
    this.verify(args);
  }

  @HostListener('focus')
  public onFocus() {
    const text = this.getValueWithoutSuffix();
    // If we set the position here directly mouse down will reset it after that
    // We need to delay this in order to override the mouse down behavior
    setTimeout(() => this.nativeElement.setSelectionRange(text.length, text.length));
  }

  private get regEx() {
    switch (this.type) {
      case '':
      case 'number':
        return new RegExp(NUMBER_FORMAT);
      case 'int':
        return new RegExp(INTEGER_FORMAT);
      case 'custom':
        return new RegExp(this.customFormat);
      default:
        throw Error('Unknown format');
    }
  }

  private get nativeElement(): HTMLInputElement {
    return this.element.nativeElement;
  }

  private verify(args: KeyboardEvent) {
    let text = this.getValueWithoutSuffix();

    text = this.getTextAfterKeyPress(text, args.key);

    if ((this.regEx.test(text) || text === '') && text + this.suffix !== this.nativeElement.value) {
      const currentPostion = this.nativeElement.selectionStart;
      const backspaceOffset = currentPostion === this.nativeElement.selectionEnd ? 1 : 0;
      const position = args.key === 'Backspace' ? currentPostion - backspaceOffset :
                      (args.key === 'Delete' ? currentPostion : currentPostion + 1);
      this.updateValue(text, position);
    }

    if (args.key.length === 1 || args.key === 'Backspace' || args.key === 'Delete') {
      args.preventDefault();
    }
  }

  private changeSuffix(oldSuffix: string) {
    if (this.nativeElement.value.length > 1) {
      const text = this.getValueWithoutSuffix(oldSuffix);
      this.updateValue(text, text.length);
    }
  }

  private getTextAfterKeyPress(text: string, key: string): string {
    const selectionStart = Math.min(this.nativeElement.selectionStart, this.nativeElement.selectionEnd);
    const selectionEnd = Math.max(this.nativeElement.selectionStart, this.nativeElement.selectionEnd);
    const selectionLength = Math.abs(selectionEnd - selectionStart);

    if (key === 'Backspace' && selectionStart <= text.length) {
      text = text.substring(0, selectionLength > 0 ? selectionStart : selectionStart - 1) +
             text.substring(selectionEnd, text.length);
    } else if (key === 'Delete') {
      text = text.substring(0, selectionStart) +
             text.substring(selectionLength > 0 ? selectionEnd : selectionEnd + 1, text.length);
    } else if (key.length === 1) {
      text = text.substring(0, selectionStart) + key + text.substring(selectionEnd, text.length);
    }

    return text;
  }

  private getValueWithoutSuffix(suffix?: string) {
    if (suffix === undefined) {
      suffix = this.suffix;
    }

    let text = this.nativeElement.value;

    if (text.length > 1 && suffix) {
      const hasSuffix = text.lastIndexOf(suffix) + suffix.length === text.length;
      if (hasSuffix) {
        text = text.substring(0, text.length - suffix.length);
      }
    }

    return text;
  }

  private updateValue(text: string, selectionIndex: number) {
    if (this.fcn) {
      this.fcn.control.setValue(text);
    }

    this.nativeElement.value = text.length ? text + this.suffix : '';
    this.nativeElement.setSelectionRange(selectionIndex, selectionIndex);
  }
}
