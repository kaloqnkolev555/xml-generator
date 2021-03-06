import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MapObjectsToAreaComponent } from './containers';
import { IMapObjectsToArea } from './interfaces/map-objects-to-area.interface';
import { ObjectsResolver } from '@app/xml-data-maintenance/objects/resolvers/objects-resolver.service';
import { AreasResolver } from '../resolvers/areas-resolver.service';
import { IObject, IArea } from '../../../common/interfaces';
import { CanDeactivateFormChangesGuard } from '@app/shared/services/can-deactivate-form-changes.service';

export interface IMapObjectToAreasComponentResolve {
  mapObjectsToArea: IMapObjectsToArea[];
  objects: IObject[];
  areas: IArea[];
}

const routes: Routes = [
  {
    path: '',
    component: MapObjectsToAreaComponent,
    resolve: {
      objects: ObjectsResolver,
      areas: AreasResolver,
    },
    canDeactivate: [CanDeactivateFormChangesGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MapObjectToAreasRoutingModule {}
