import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaAreaToObjectComponent } from './cg-meta-area-to-object.component';

describe('CgMetaAreaToObjectComponent', () => {
  let component: CgMetaAreaToObjectComponent;
  let fixture: ComponentFixture<CgMetaAreaToObjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaAreaToObjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaAreaToObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
