import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectMaintenanceComponent } from './object-maintenance.component';

describe('ObjectMaintenanceComponent', () => {
  let component: ObjectMaintenanceComponent;
  let fixture: ComponentFixture<ObjectMaintenanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ObjectMaintenanceComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
