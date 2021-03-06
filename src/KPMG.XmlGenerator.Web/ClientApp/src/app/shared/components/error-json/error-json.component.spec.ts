import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrorJsonComponent } from './error-json.component';
import { TranslateModule } from '@ngx-translate/core';

describe('ErrorJsonComponent', () => {
  let component: ErrorJsonComponent;
  let fixture: ComponentFixture<ErrorJsonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ErrorJsonComponent ],
      imports: [ TranslateModule.forRoot() ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ErrorJsonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
