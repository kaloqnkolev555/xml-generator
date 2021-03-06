import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaTechnicalSettingFormComponent } from './cg-meta-technical-setting-form.component';

describe('CgMetaTechnicalSettingFormComponent', () => {
  let component: CgMetaTechnicalSettingFormComponent;
  let fixture: ComponentFixture<CgMetaTechnicalSettingFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CgMetaTechnicalSettingFormComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaTechnicalSettingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
