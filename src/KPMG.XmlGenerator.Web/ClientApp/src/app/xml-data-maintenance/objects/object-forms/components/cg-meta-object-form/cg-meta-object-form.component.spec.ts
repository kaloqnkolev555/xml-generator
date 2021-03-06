import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaObjectFormComponent } from './cg-meta-object-form.component';

describe('CgMetaObjectFormComponent', () => {
  let component: CgMetaObjectFormComponent;
  let fixture: ComponentFixture<CgMetaObjectFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CgMetaObjectFormComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaObjectFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
