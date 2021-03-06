import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteConfigurationComponent } from './delete-configuration.component';

describe('DeleteConfigurationComponent', () => {
  let component: DeleteConfigurationComponent;
  let fixture: ComponentFixture<DeleteConfigurationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteConfigurationComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
