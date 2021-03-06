import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchSelectOptionComponent } from './search-select-option.component';

describe('SearchSelectOptionComponent', () => {
  let component: SearchSelectOptionComponent;
  let fixture: ComponentFixture<SearchSelectOptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SearchSelectOptionComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchSelectOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
