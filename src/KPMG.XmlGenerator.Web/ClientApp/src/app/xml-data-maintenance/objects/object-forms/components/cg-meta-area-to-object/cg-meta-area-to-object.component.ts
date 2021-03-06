import { Component, OnInit, Inject } from '@angular/core';
import { IArea } from '@app/common/interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { take, filter } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms';
import {
  IcgMetaObjectOutput,
  IMappedAreas,
} from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';
import { CreateObjectSteps, stepsData } from '../../../objects-shared-module/resources';

@Component({
  selector: 'app-cg-meta-area-to-object',
  templateUrl: './cg-meta-area-to-object.component.html',
  styleUrls: ['./cg-meta-area-to-object.component.scss'],
})
export class CgMetaAreaToObjectComponent implements OnInit {
  private _canILeave = false;
  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_META_TECHNICAL_SETTING}`;

  public areas: IArea[] = [];
  public areaToObjectForm: FormGroup;
  public cgMetaObjectDTO: IcgMetaObjectOutput;

  constructor(
    private readonly fb: FormBuilder,
    private readonly createObjectService: CreateObjectService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly confirmationPopUp: ConfirmationPopUpService
  ) {}

  ngOnInit() {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.areas = data.areas;
    });

    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');
    const stepData = this.createObjectService.getData('mappedAreas');

    this.buildTheForm(stepData);
  }

  private buildTheForm(stepData: IMappedAreas) {
    this.areaToObjectForm = this.fb.group({
      mappedAreas: this.fb.control(stepData.mappedAreas),
    });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public nextStep() {
    this.markAsTouched(this.areaToObjectForm);
    if (!this.areaToObjectForm.valid) return;

    const stepData = this.areaToObjectForm.value;
    const isStepDifferent = this.createObjectService.isStepDifferent('mappedAreas', stepData);
    const isStepPassed = this.createObjectService.isStepPassed('mappedAreas');

    if (!Array.isArray(stepData.mappedAreas)) return false;

    if (stepData.mappedAreas.length === 0) {
      this.confirmationPopUp
        .open({
          title: 'Warning!',
          description: 'No area mapping has been selected. Are you sure you want to continue?',
        })
        .pipe(
          take(1),
          filter(result => result)
        )
        .subscribe(() => this.submitData(stepData, isStepDifferent, isStepPassed));
    } else {
      this.submitData(stepData, isStepDifferent, isStepPassed);
    }
  }

  private submitData(stepData, isStepDifferent: boolean, isStepPassed: boolean) {
    if (isStepDifferent && isStepPassed) {
      this.createObjectService.setData('mappedAreas', stepData, true);
    } else {
      this.createObjectService.setData('mappedAreas', stepData, false);
    }

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_COLUMN_MAPPING}`], { relativeTo: this.route.parent });
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_META_TECHNICAL_SETTING}`], { relativeTo: this.route.parent });
  }
}
