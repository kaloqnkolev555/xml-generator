import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectOverviewComponent } from './object-overview.component';

describe('ObjectOverviewComponent', () => {
  let component: ObjectOverviewComponent;
  let fixture: ComponentFixture<ObjectOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjectOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
