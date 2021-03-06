import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IObject, IVariants } from '../../../../../common/interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { existingPropertyValidator } from '../../../../../common/form-validators/existing-property.validator';
import { VariantsService } from '../../../../../xml-data-maintenance/configurations-variants/configurations-variants.service';
import { ICanILeave } from '../../../../../common/interfaces/can-i-leave.interface';
import { take, takeUntil } from 'rxjs/operators';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '../../../../../common/forms/mark-all-as-touched.forms';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';

const VARIANT_NAME_MAX_LENGTH = 70;

enum TabsName {
  NONE = 'None',
  EXISTING_VARIANT = 'Existing Variant',
}

interface ITab {
  name: TabsName;
}

enum FormControls {
  VARIANT_NAME = 'variantName',
}

@Component({
  selector: 'app-create-variant',
  templateUrl: './create-variant.component.html',
  styleUrls: ['./create-variant.component.scss'],
})
export class CreateVariantComponent implements OnInit, OnDestroy, ICanILeave {
  private _canILeave = false;
  private unsubscribe = new Subject();

  public createVariantForm: FormGroup;

  public tabsName = TabsName;
  public mainTitle = 'Create New Variant';
  public objects: IObject[] = [];
  public variants: IVariants[] = [];

  public selectVariantCTR = new FormControl(null, [Validators.required]);
  public selectedObjectsCTR = new FormControl([], [Validators.required]);

  public tabs: ITab[] = [
    {
      name: TabsName.NONE,
    },
    {
      name: TabsName.EXISTING_VARIANT,
    },
  ];

  public formControls = FormControls;

  public create_variant_errors: IErrorSet = {
    variantName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${VARIANT_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-variantName', message: 'Please enter unique name' },
    ],
    templateCgMetaVariantIdColumn: [{ type: 'required', message: 'Mandatory field' }],
    mapMetaObjctIdColumns: [{ type: 'required', message: 'Mandatory field' }],
  };

  public activeTab: ITab;

  constructor(
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute,
    private readonly variantService: VariantsService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      this.objects = data.objects;
      this.variants = data.variants;
    });

    this.buildTheForm();
    this.select(this.tabs[0]);
  }

  private buildTheForm(): void {
    this.createVariantForm = this.fb.group(
      {
        variant: this.fb.group({
          variantName: this.fb.control('', [
            Validators.required,
            Validators.maxLength(VARIANT_NAME_MAX_LENGTH),
            existingPropertyValidator(this.variants, 'variantName'),
          ]),
          versionId: 1, // TODO
        }),
      },
      {
        updateOn: 'submit',
      }
    );
  }

  private addTemplateCgMetaVariantIdColumn(): void {
    this.createVariantForm.addControl('templateCgMetaVariantIdColumn', this.selectVariantCTR);
  }

  private removeTemplateCgMetaVariantIdColumn(): void {
    this.createVariantForm.removeControl('templateCgMetaVariantIdColumn');
  }

  private addMapMetaObjctIdColumns(): void {
    this.createVariantForm.addControl('mapMetaObjctIdColumns', this.selectedObjectsCTR);
  }

  private removeMapMetaObjctIdColumns(): void {
    this.createVariantForm.removeControl('mapMetaObjctIdColumns');
  }

  public select(tab: ITab): void {
    this.activeTab = tab;

    if (tab.name === TabsName.NONE) {
      this.removeTemplateCgMetaVariantIdColumn();
      this.addMapMetaObjctIdColumns();
    }

    if (tab.name === TabsName.EXISTING_VARIANT) {
      this.removeMapMetaObjctIdColumns();
      this.addTemplateCgMetaVariantIdColumn();
    }
  }

  public createVariant(): void {
    this.markAsTouched(this.createVariantForm);
    if (!this.createVariantForm.valid) return;
    this.variantService
      .createVariant(this.createVariantForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this._canILeave = true;
        this.toastr.success('You have created a new variant!');
        this.router.navigate(['/xml-data-maintenance/configurations-variants']);
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
