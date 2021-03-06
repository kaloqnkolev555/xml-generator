import { Component, ElementRef, EventEmitter, forwardRef, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import * as ace from 'ace-builds';
import 'ace-builds/src-noconflict/mode-sqlserver';
import 'ace-builds/src-noconflict/theme-sqlserver';

@Component({
  selector: 'app-hard-constraint-query-editor',
  templateUrl: './hard-constraint-query-editor.component.html',
  styleUrls: ['./hard-constraint-query-editor.component.scss'],
  providers: [
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => HardConstraintQueryEditorComponent), multi: true },
  ]
})
export class HardConstraintQueryEditorComponent implements OnInit, ControlValueAccessor {
  private _readonly: boolean = false;
  private _editorValue: string;

  @ViewChild('queryEditorEl', { static: true }) queryEditorElRef: ElementRef;
  private queryEditor: ace.Ace.Editor;

  @Input()
  set readonly(value: boolean) {
    this._readonly = value;
    if (this.queryEditor) {
      this.queryEditor.setReadOnly(value);
    }
  }
  get readonly(): boolean {
    return this._readonly;
  }
  @Output() onLoad: EventEmitter<any> = new EventEmitter<any>();

  public validationErrors: string[] = [];
  public serverValidationErrors: string[] = [];

  constructor(
  ) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    const editorElement = this.queryEditorElRef.nativeElement;
    const editorOptions: Partial<ace.Ace.EditorOptions> = {
      minLines: 8,
      maxLines: Infinity,
      highlightActiveLine: true,
      printMargin: 70,
      fontSize: 14,
      showLineNumbers: true,
      highlightGutterLine: true,
      showGutter: true,
      highlightSelectedWord: true,
      behavioursEnabled: true,
      dragEnabled: true,
      readOnly: this._readonly,
    };
    this.queryEditor = ace.edit(editorElement, editorOptions);
    this.queryEditor.setTheme('ace/theme/sqlserver');
    this.queryEditor.getSession().setMode('ace/mode/sqlserver');

    this.queryEditor.getSession().setValue(this._editorValue || '');

    this.onLoad.emit(this.queryEditor);

    this.queryEditor.on('change', (delta: ace.Ace.Delta) => {
      const constraint = this.queryEditor.getValue();
      this._editorValue = constraint;
      this.propagateChange(constraint, delta);
      this.propagateBlur();
    });
  }

  writeValue(value: string): void {
    this._editorValue = value || '';
    if (this.queryEditor) {
      this.queryEditor.getSession().setValue(this._editorValue);
    }
    this.propagateChange(value)
    this.propagateBlur();
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.propagateBlur = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this._readonly = !!isDisabled;
    if (this.queryEditor) {
      this.queryEditor.setReadOnly(this._readonly);
    }
  }

  private propagateChange = (costraint: string, delta?: ace.Ace.Delta) => { };
  private propagateBlur = () => { };
}
