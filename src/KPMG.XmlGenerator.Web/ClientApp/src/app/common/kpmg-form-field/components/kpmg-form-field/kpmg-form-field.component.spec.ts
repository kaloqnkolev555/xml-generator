import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KpmgFormFieldComponent } from './kpmg-form-field.component';

describe('KpmgFormFieldComponent', () => {
  let component: KpmgFormFieldComponent;
  let fixture: ComponentFixture<KpmgFormFieldComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KpmgFormFieldComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KpmgFormFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
