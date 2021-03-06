import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XmlDataMaintenanceComponent } from './xml-data-maintenance.component';

describe('XmlDataMaintenanceComponent', () => {
  let component: XmlDataMaintenanceComponent;
  let fixture: ComponentFixture<XmlDataMaintenanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XmlDataMaintenanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XmlDataMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
