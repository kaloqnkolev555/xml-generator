import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaHconstraintToAreaComponent } from './cg-meta-hconstraint-to-area.component';

describe('CgMetaHconstraintToAreaComponent', () => {
  let component: CgMetaHconstraintToAreaComponent;
  let fixture: ComponentFixture<CgMetaHconstraintToAreaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaHconstraintToAreaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaHconstraintToAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
