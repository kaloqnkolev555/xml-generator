import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VariantObjectMappingComponent } from './variant-object-mapping.component';

describe('VariantObjectMappingComponent', () => {
  let component: VariantObjectMappingComponent;
  let fixture: ComponentFixture<VariantObjectMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [VariantObjectMappingComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VariantObjectMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
