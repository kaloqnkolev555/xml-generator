import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KpmgFormFieldErrorSetComponent } from './kpmg-form-field-error-set.component';

describe('KpmgFormFieldErrorSetComponent', () => {
  let component: KpmgFormFieldErrorSetComponent;
  let fixture: ComponentFixture<KpmgFormFieldErrorSetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KpmgFormFieldErrorSetComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KpmgFormFieldErrorSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
