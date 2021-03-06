import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectOverviewObjectInfoComponent } from './object-overview-object-info.component';

describe('ObjectOverviewObjectInfoComponent', () => {
  let component: ObjectOverviewObjectInfoComponent;
  let fixture: ComponentFixture<ObjectOverviewObjectInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjectOverviewObjectInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectOverviewObjectInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
