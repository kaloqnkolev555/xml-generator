import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapObjectsToAreaComponent } from './map-objects-to-area.component';

describe('MapObjectsToAreaComponent', () => {
  let component: MapObjectsToAreaComponent;
  let fixture: ComponentFixture<MapObjectsToAreaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapObjectsToAreaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapObjectsToAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
