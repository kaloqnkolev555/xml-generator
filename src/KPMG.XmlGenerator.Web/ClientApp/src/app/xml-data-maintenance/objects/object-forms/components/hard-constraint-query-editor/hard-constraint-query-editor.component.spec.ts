import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HardConstraintQueryEditorComponent } from './hard-constraint-query-editor.component';

describe('HardConstraintQueryEditorComponent', () => {
  let component: HardConstraintQueryEditorComponent;
  let fixture: ComponentFixture<HardConstraintQueryEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HardConstraintQueryEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HardConstraintQueryEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
