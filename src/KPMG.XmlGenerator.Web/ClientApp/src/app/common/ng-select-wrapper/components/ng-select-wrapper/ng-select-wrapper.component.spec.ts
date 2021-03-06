import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NgSelectWrapperComponent } from './ng-select-wrapper.component';

describe('NgSelectWrapperComponent', () => {
  let component: NgSelectWrapperComponent;
  let fixture: ComponentFixture<NgSelectWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NgSelectWrapperComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgSelectWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
