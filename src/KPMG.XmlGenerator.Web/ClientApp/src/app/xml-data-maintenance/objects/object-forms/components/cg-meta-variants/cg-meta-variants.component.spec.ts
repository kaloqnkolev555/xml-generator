import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaVariantsComponent } from './cg-meta-variants.component';

describe('CgMetaVariantsComponent', () => {
  let component: CgMetaVariantsComponent;
  let fixture: ComponentFixture<CgMetaVariantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaVariantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaVariantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
