import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnDestroy,
  InjectionToken,
  Inject,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
} from '@angular/core';

export interface SearchSelectParentComponent {
  multiple?: boolean;
}

export const SEARCH_SELECT_PARENT_COMPONENT = new InjectionToken<SearchSelectParentComponent>(
  'SEARCH_SELECT_PARENT_COMPONENT'
);

export interface ISearchSelectOptionChange {
  value: any;
  option: SearchSelectOptionComponent;
  automaticallyChanged: boolean;
}

@Component({
  selector: 'app-search-select-option',
  templateUrl: './search-select-option.component.html',
  styleUrls: ['./search-select-option.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchSelectOptionComponent implements OnDestroy {
  private _isSelected: boolean;

  @Input()
  public set isSelected(value: boolean) {
    this._isSelected = value;
    this.cd.detectChanges();
  }

  public get isSelected() {
    return this._isSelected;
  }

  public _isDisabled = false;
  public _showCheckBox = false;

  @Input() public value: any;
  @Input() public searchValue: string | number;
  @Input() public hide = false;
  @Output() public valueChange = new EventEmitter<ISearchSelectOptionChange>();

  constructor(
    @Inject(SEARCH_SELECT_PARENT_COMPONENT)
    private _parent: SearchSelectParentComponent,
    private cd: ChangeDetectorRef
  ) {}

  public select(autoSelect = false): void {
    if (!this.isSelected) {
      this.isSelected = true;
      this.valueChange.emit({
        value: this.value,
        option: this,
        automaticallyChanged: autoSelect,
      });
    }
  }

  public get isMulti() {
    return this._parent.multiple;
  }

  public set isDisabled(value: boolean) {
    this._isDisabled = value;
    this.cd.detectChanges();
  }

  public get isDisabled() {
    return this._isDisabled;
  }

  public deselect(autoDeselect = false): void {
    if (this.isSelected) {
      this.isSelected = false;
      this.valueChange.emit({
        value: '',
        option: this,
        automaticallyChanged: autoDeselect,
      });
    }
  }

  public showOption(): void {
    this.hide = false;
    this.cd.detectChanges();
  }

  public hideOption(): void {
    this.hide = true;
    this.cd.detectChanges();
  }

  public selectOption() {
    this.isSelected ? this.deselect() : this.select();
  }

  public ngOnDestroy(): void {
    this.valueChange.complete();
  }
}
