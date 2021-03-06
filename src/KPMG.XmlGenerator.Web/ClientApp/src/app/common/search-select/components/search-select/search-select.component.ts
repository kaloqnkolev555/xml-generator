import {
  Component,
  forwardRef,
  Input,
  QueryList,
  AfterViewInit,
  ContentChildren,
  OnInit,
  OnDestroy,
  Optional,
  Host,
  SkipSelf,
} from '@angular/core';
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormControl,
  ControlContainer,
  AbstractControl,
} from '@angular/forms';
import {
  SearchSelectOptionComponent,
  ISearchSelectOptionChange,
  SEARCH_SELECT_PARENT_COMPONENT,
} from '../search-select-option/search-select-option.component';
import { merge, Observable, Subject } from 'rxjs';
import { takeUntil, filter } from 'rxjs/operators';
import { IFormFieldErrorSet } from '@app/common/kpmg-form-field/components';

const MIN_LENGTH_FOR_SEARCHING = 3;

@Component({
  selector: 'app-search-select',
  templateUrl: './search-select.component.html',
  styleUrls: ['./search-select.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SearchSelectComponent),
      multi: true,
    },
    { provide: SEARCH_SELECT_PARENT_COMPONENT, useExisting: SearchSelectComponent },
  ],
})
export class SearchSelectComponent implements OnInit, ControlValueAccessor, AfterViewInit, OnDestroy {
  private unsubscribe = new Subject();

  private isDisabled = false;
  private selectedValue: any;
  private checkedSelected = false;

  public searchCTR = new FormControl('');
  public noItemFound = false;
  public searchSelectOptions: QueryList<SearchSelectOptionComponent>;

  @Input() public multiple = false;
  @Input() public errorSet: IFormFieldErrorSet[] = [];

  @Input() public formControl: FormControl;
  @Input() formControlName: string;

  @Input() public keys: string[] = ['id'];

  public control: AbstractControl;

  @ContentChildren(SearchSelectOptionComponent)
  set content(content: QueryList<SearchSelectOptionComponent>) {
    this.searchSelectOptions = content;
    this.setUpSelectedOption();
    this.searchSelectOptions.forEach(option => {
      option.isDisabled = this.isDisabled;
    });
  }

  constructor(
    @Optional()
    @Host()
    @SkipSelf()
    private controlContainer: ControlContainer
  ) {}

  public ngOnInit(): void {
    if (this.controlContainer && this.formControlName) {
      this.control = this.controlContainer.control.get(this.formControlName);
    }

    if (this.formControl) {
      this.control = this.formControl;
    }

    this.searchCTR.valueChanges
      .pipe(
        filter(value => value.length > MIN_LENGTH_FOR_SEARCHING || value.length === 0),
        takeUntil(this.unsubscribe)
      )
      .subscribe(value => {
        const matches = this.searchSelectOptions.reduce((acc, option) => {
          if (
            !option.searchValue
              .toString()
              .toLowerCase()
              .includes(value.toLowerCase())
          ) {
            option.hideOption();
            return acc;
          }

          option.showOption();
          return (acc += 1);
        }, 0);

        matches > 0 ? (this.noItemFound = false) : (this.noItemFound = true);
      });
  }

  public ngAfterViewInit(): void {
    const eventEmitters = this.searchSelectOptions.reduce(
      (acc, value) => {
        acc.push(value.valueChange.asObservable());
        return acc;
      },
      [] as Observable<ISearchSelectOptionChange>[]
    );
    merge(...eventEmitters)
      .pipe(
        filter(el => !el.automaticallyChanged),
        takeUntil(this.unsubscribe)
      )
      .subscribe(option => {
        this.optionValueChange(option);
      });
  }

  private optionValueChange(option: ISearchSelectOptionChange): void {
    if (!this.multiple) {
      this.selectedValue = option.value;

      if (option.value === null) return;

      this.searchSelectOptions.forEach(optionElement => {
        if (optionElement === option.option) return;
        if (optionElement.isSelected) optionElement.deselect(true);
      });
    }

    if (this.multiple) {
      this.selectedValue = this.searchSelectOptions.reduce((acc, selectOption) => {
        if (selectOption.isSelected) acc.push(selectOption.value);
        return acc;
      }, []);
    }

    this.propagateChange(this.selectedValue);
  }

  // tslint:disable-next-line:no-empty
  public propagateChange: (_: any) => void = (_: any) => {};

  public registerOnTouched(fn: any): void {
    return;
  }

  public setDisabledState(isDisabled: boolean) {
    if (this.searchSelectOptions) {
      this.searchSelectOptions.forEach(option => {
        option.isDisabled = isDisabled;
      });
    }

    this.isDisabled = isDisabled;
  }

  private toggleAll(isSelected) {
    if (this.isDisabled) return;
    if (isSelected) {
      this.searchSelectOptions.forEach(option => {
        if (!option.hide) {
          option.select(false);
        }
      });
    } else {
      this.searchCTR.setValue('');
      this.searchSelectOptions.forEach(option => {
        option.deselect(false);
        this.checkedSelected = false;
        option.showOption();
      });
    }
  }

  private selectedOnTop() {
    if (this.isDisabled) return;
    if (!this.checkedSelected) {
      this.checkedSelected = true;
      this.searchCTR.setValue('');
    } else {
      this.checkedSelected = false;
    }
    this.searchSelectOptions.forEach(option => {
      if (this.checkedSelected && option.isSelected) {
        option.showOption();
      } else if (this.checkedSelected && this.selectedValue.length !== 0) {
        option.hideOption();
      } else if (!this.checkedSelected) {
        option.showOption();
      }
    });
  }

  private setUpSelectedOption() {
    this.searchSelectOptions.length > 0 ? (this.noItemFound = false) : (this.noItemFound = true);
    if (Array.isArray(this.selectedValue) && this.multiple) {
      this.searchSelectOptions.forEach(option => {
        if (this.selectedValue.find(v => this.compareValues(v, option.value))) {
          option.select(true);
        } else {
          option.deselect(true);
        }
      });
    } else {
      this.searchSelectOptions.forEach(el => {
        if (this.compareValues(el.value, this.selectedValue)) {
          el.select(true);
        } else {
          el.deselect(true);
        }
      });
    }
  }

  private compareValues(obj1, obj2) {
    if (typeof obj1 === 'object' && typeof obj2 === 'object' && !!this.keys && this.keys.length > 0)
      return this.keys.every(key => obj1.hasOwnProperty(key) && obj2.hasOwnProperty(key) && obj1[key] === obj2[key]);
    return '' + obj1 === '' + obj2;
  }

  public registerOnChange(fn): void {
    this.propagateChange = fn;
  }

  public writeValue(value): void {
    if (!!value) {
      this.selectedValue = value;
    }

    if (this.searchSelectOptions) {
      this.setUpSelectedOption();
    }
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
