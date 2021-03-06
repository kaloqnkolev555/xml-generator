import { RouterStateSnapshot, ActivatedRouteSnapshot, Router, CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { CreateObjectService } from '../create-object.service';
import { CreateObjectSteps, stepsData } from '../objects-shared-module/resources';

@Injectable({
  providedIn: 'root',
})
export class StepsRedirectGuard implements CanActivate {
  constructor(
    private readonly router: Router,
    private readonly createObjectService: CreateObjectService,
  ) {}

  private canIBeHere(routePath: CreateObjectSteps): boolean {
    switch (routePath) {
      case CreateObjectSteps.CG_META_OBJECT:
        return true;
      case CreateObjectSteps.CG_META_TECHNICAL_SETTING:
        return this.createObjectService.isStepPassed('cgMetaObjectDTO');
      case CreateObjectSteps.CG_AREA_MAPPING:
        return this.createObjectService.isStepPassed('cgMetaObjectTechnicalSettings');
      case CreateObjectSteps.CG_COLUMN_MAPPING:
        return this.createObjectService.isStepPassed('mappedAreas');
      case CreateObjectSteps.CG_CONSTRAINT:
        return this.createObjectService.isStepPassed('mappedColumns');
      case CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA:
        return this.createObjectService.isStepPassed('cgMetaConstraintsArea');
      case CreateObjectSteps.CG_VARIANT_MAPPING:
        return this.createObjectService.isStepPassed('hardCodedConstraints');
      case CreateObjectSteps.OBJECT_OVERVIEW:
        return this.createObjectService.isStepPassed('cgMetaVariantToObject');
      default:
        return false;
    }
  }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const canBeHere = this.canIBeHere(route.routeConfig.path as CreateObjectSteps);
    if (canBeHere) return true;

    const firstInvalidStep = this.createObjectService.firstInvalidStep();
    const theStep = stepsData[firstInvalidStep];

    const url = state.url.split('/');
    url.pop();

    this.router.navigate([`${url.join('/')}/${theStep.url}`]);
    return true;
  }
}
