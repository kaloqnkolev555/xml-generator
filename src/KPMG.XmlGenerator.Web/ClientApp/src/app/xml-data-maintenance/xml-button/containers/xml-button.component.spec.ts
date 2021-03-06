import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XmlButtonComponent } from './xml-button.component';

describe('XmlButtonComponent', () => {
  let component: XmlButtonComponent;
  let fixture: ComponentFixture<XmlButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [XmlButtonComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XmlButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
