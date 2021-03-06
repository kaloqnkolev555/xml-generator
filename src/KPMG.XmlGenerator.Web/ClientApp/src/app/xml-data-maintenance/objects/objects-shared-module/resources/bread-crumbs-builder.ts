import { stepsOrder, stepsData, CreateObjectSteps } from './steps-resources';
import { IBreadcrumb } from '@app/common/secondary-header';
import { InjectionToken } from '@angular/core';

export type BreadCrumbsBuilder = (step: string) => IBreadcrumb[];

const findTheStep = (step: string) => {
  switch (step) {
    case CreateObjectSteps.CG_META_OBJECT:
      return CreateObjectSteps.CG_META_OBJECT;
    case CreateObjectSteps.CG_META_TECHNICAL_SETTING:
      return CreateObjectSteps.CG_META_TECHNICAL_SETTING;
    case CreateObjectSteps.CG_AREA_MAPPING:
      return CreateObjectSteps.CG_AREA_MAPPING;
    case CreateObjectSteps.CG_COLUMN_MAPPING:
      return CreateObjectSteps.CG_COLUMN_MAPPING;
    case CreateObjectSteps.CG_CONSTRAINT:
      return CreateObjectSteps.CG_CONSTRAINT;
    case CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA:
      return CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA;
    case CreateObjectSteps.CG_VARIANT_MAPPING:
      return CreateObjectSteps.CG_VARIANT_MAPPING;
    case CreateObjectSteps.OBJECT_OVERVIEW:
      return CreateObjectSteps.OBJECT_OVERVIEW;
    default:
      return step;
  }
};

export const breadCrumbsBuilder: BreadCrumbsBuilder = (step: string) => {
  const theStep = findTheStep(step);
  if (!theStep) return [];

  const stepIndex = stepsOrder.findIndex(el => el === theStep);

  return Array.from({ length: stepIndex + 1 }, (el, index) => {
    const stepName = stepsOrder[index];
    const { url, label, stepTitle } = stepsData[stepName];

    return {
      step: stepName,
      stepTitle,
      url,
      label,
    };
  });
};

export const BREAD_CRUMBS_BUILDER = new InjectionToken('bread.crumbs_builder');
