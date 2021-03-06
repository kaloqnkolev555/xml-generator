import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapObjectsToAreaComponent } from './containers/map-objects-to-area/map-objects-to-area.component';
import { SharedModule } from '@app/shared/shared.module';
import { MapObjectToAreasRoutingModule } from './map-objects-to-area-routing.module';
import { MapObjectsToAreaRepository } from './map-objects-to-area-repository.service';
import { MapObjectsToAreaService } from './map-objects-to-area.service';
import { ObjectsModule } from '../../objects/objects.module';
import { SecondaryHeaderModule } from '@app/common/secondary-header/secondary-header.module';

@NgModule({
  declarations: [MapObjectsToAreaComponent],
  imports: [CommonModule, SharedModule, MapObjectToAreasRoutingModule, ObjectsModule, SecondaryHeaderModule],
  providers: [MapObjectsToAreaRepository, MapObjectsToAreaService],
})
export class MapObjectsToAreaModule {}
