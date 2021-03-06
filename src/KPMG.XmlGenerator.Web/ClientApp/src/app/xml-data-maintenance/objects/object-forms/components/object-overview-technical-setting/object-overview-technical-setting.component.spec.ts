import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectOverviewTechnicalSettingComponent } from './object-overview-technical-setting.component';

describe('ObjectOverviewTechnicalSettingComponent', () => {
  let component: ObjectOverviewTechnicalSettingComponent;
  let fixture: ComponentFixture<ObjectOverviewTechnicalSettingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjectOverviewTechnicalSettingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectOverviewTechnicalSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
