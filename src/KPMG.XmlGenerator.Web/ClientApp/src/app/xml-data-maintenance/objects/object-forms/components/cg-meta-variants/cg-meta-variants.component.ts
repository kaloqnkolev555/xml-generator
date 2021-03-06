import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import { IcgMetaObjectOutput, IVariantOutput, IVariant } from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { CreateObjectSteps } from '@app/xml-data-maintenance/objects/objects-shared-module/resources';
import * as _ from 'lodash';
import { filter, take } from 'rxjs/operators';

@Component({
  selector: 'app-cg-meta-variants',
  templateUrl: './cg-meta-variants.component.html',
  styleUrls: ['./cg-meta-variants.component.scss'],
})
export class CgMetaVariantsToObjectComponent implements OnInit {
  constructor(
    private readonly fb: FormBuilder,
    private readonly createObjectService: CreateObjectService,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly confirmationPopUp: ConfirmationPopUpService,
    private cd: ChangeDetectorRef
  ) {}

  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA}`;
  private _canILeave = false;
  public cgMetaObjectDTO: IcgMetaObjectOutput;
  public createForm: FormGroup;
  public stepData;
  public configurations = new Map<string, string[]>();

  ngOnInit() {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.stepData = data;
    });
    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');
    const stepSelection = this.createObjectService.getData('cgMetaVariantToObject');
    this.buildTheForm(stepSelection);
    this.enumerateConfigurations();
  }

  private buildTheForm(stepSelection: IVariantOutput) {
    const variantsCtrl = this.fb.control(stepSelection.variants);
    this.createForm = this.fb.group({
      variants: variantsCtrl,
    });
    variantsCtrl.valueChanges.subscribe((value) => { this.enumerateConfigurations(); });
  }

  public enumerateConfigurations() {
    const configsMap = new Map<string, string[]>();
    const mappedVariants = <IVariant[]>this.createForm.get('variants').value;
    mappedVariants.forEach(v => v.mappedConfigurations.forEach(c => {
      if (!c.configurationName) return;
      if (configsMap.has(c.configurationName)) {
        configsMap.get(c.configurationName).push(v.variantName);
      } else {
        configsMap.set(c.configurationName, [v.variantName]);
      }
    }));

    this.configurations = configsMap;
    this.cd.detectChanges();
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public nextStep() {
    const stepData = this.createForm.value;

    if (stepData.variants.length === 0) {
      this.confirmationPopUp
        .open({
          title: 'Warning!',
          description: 'No variant mapping has been selected. Are you sure you want to continue?',
        })
        .pipe(
          take(1),
          filter(result => result)
        )
        .subscribe(() => {
          this.setDataAndNavigateNext();
        });
    } else if (Array.from(this.configurations.values()).find(arr => arr.length > 1)) {
      this.confirmationPopUp
        .open({
          title: 'Warning!',
          description:
            'With the currently selected variant mapping, the Object will be included in multiple Configs. Are you sure you want to continue?',
        })
        .pipe(
          take(1),
          filter(result => result)
        )
        .subscribe(() => {
          this.setDataAndNavigateNext();
        });
    } else {
      this.setDataAndNavigateNext();
    }
  }

  private setDataAndNavigateNext() {
    const stepData = this.createForm.value;
    this.createObjectService.setData('cgMetaVariantToObject', stepData, false);
    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.OBJECT_OVERVIEW}`], { relativeTo: this.route.parent });
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_HARD_CONSTRAINT_TO_AREA}`], { relativeTo: this.route.parent });
  }
}
