import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaConstraintComponent } from './cg-meta-constraint.component';

describe('CgMetaConstraintComponent', () => {
  let component: CgMetaConstraintComponent;
  let fixture: ComponentFixture<CgMetaConstraintComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaConstraintComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaConstraintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
