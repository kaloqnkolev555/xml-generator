import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurationsVariantsMaintenanceComponent } from './configurations-variants-maintenance.component';

describe('ConfigurationsVariantsMaintenanceComponent', () => {
  let component: ConfigurationsVariantsMaintenanceComponent;
  let fixture: ComponentFixture<ConfigurationsVariantsMaintenanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ConfigurationsVariantsMaintenanceComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurationsVariantsMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
