import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaMaintenanceComponent } from './area-maintenance.component';

describe('AreaMaintenanceComponent', () => {
  let component: AreaMaintenanceComponent;
  let fixture: ComponentFixture<AreaMaintenanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaMaintenanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
