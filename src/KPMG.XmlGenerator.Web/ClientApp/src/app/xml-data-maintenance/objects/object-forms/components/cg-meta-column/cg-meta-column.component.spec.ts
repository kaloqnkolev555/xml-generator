import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaColumnComponent } from './cg-meta-column.component';

describe('CgMetaColumnComponent', () => {
  let component: CgMetaColumnComponent;
  let fixture: ComponentFixture<CgMetaColumnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaColumnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaColumnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
