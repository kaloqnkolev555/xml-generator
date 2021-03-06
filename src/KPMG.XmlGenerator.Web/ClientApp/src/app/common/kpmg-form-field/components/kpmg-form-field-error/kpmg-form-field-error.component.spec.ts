import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KpmgFormFieldErrorComponent } from './kpmg-form-field-error.component';

describe('KpmgFormFieldErrorComponent', () => {
  let component: KpmgFormFieldErrorComponent;
  let fixture: ComponentFixture<KpmgFormFieldErrorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KpmgFormFieldErrorComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KpmgFormFieldErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
