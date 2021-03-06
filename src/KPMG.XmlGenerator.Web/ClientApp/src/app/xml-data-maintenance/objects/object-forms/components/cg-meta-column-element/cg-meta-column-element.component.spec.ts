import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CgMetaColumnElementComponent } from './cg-meta-column-element.component';

describe('CgMetaColumnElementComponent', () => {
  let component: CgMetaColumnElementComponent;
  let fixture: ComponentFixture<CgMetaColumnElementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CgMetaColumnElementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CgMetaColumnElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
