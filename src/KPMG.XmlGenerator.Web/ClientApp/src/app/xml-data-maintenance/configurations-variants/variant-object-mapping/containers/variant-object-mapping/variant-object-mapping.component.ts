import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '../../../../../common/forms/mark-all-as-touched.forms';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';
import { ToastrService } from 'ngx-toastr';
import { VariantsService } from '@app/xml-data-maintenance/configurations-variants/configurations-variants.service';
import { take, takeUntil, filter, switchMap } from 'rxjs/operators';
import { IVariants } from '@app/common/interfaces/variants.interface';
import { IObject } from '@app/common/interfaces';

@Component({
  selector: 'app-variant-object-mapping',
  templateUrl: './variant-object-mapping.component.html',
  styleUrls: ['./variant-object-mapping.component.scss'],
})
export class VariantObjectMappingComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();
  private _canILeave = false;

  public mainTitle = 'Map Objects to Variant';
  public variantObjectMapping: FormGroup;

  public variants: IVariants[];
  public objects: IObject[];

  public printSelectedVariant = '';

  public map_objects_to_errors: IErrorSet = {
    objectColumnId: [{ type: 'required', message: 'Mandatory field' }],
    variantColumnId: [{ type: 'required', message: 'Mandatory field' }],
  };

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    private readonly variantsService: VariantsService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  public ngOnInit(): void {
    this.route.data.pipe(take(1)).subscribe(result => {
      this.objects = result.objects.sort((a, b) => (a.cgMetaObjectName > b.cgMetaObjectName ? 1 : -1));
      this.variants = result.variants.sort((a, b) => (a.variantName > b.variantName ? 1 : -1));
    });

    this.buildTheForm();

    const { variantColumnId: variantsCTR, objectColumnId: objectsCTR } = this.variantObjectMapping.controls;

    variantsCTR.valueChanges
      .pipe(
        filter(value => value !== null),
        switchMap(value => this.variantsService.getVariantToObject(value)),
        takeUntil(this.unsubscribe)
      )
      .subscribe(value => {
        objectsCTR.setValue(value.objectColumnId, { emitEvent: false });
      });

    objectsCTR.valueChanges.pipe(takeUntil(this.unsubscribe)).subscribe(_ => {
      if (variantsCTR.value !== null && !variantsCTR.disabled && objectsCTR.dirty)
        variantsCTR.disable({
          emitEvent: false,
        });
    });
    this.variantObjectMapping.controls.objectColumnId.disable();
  }

  private buildTheForm() {
    this.variantObjectMapping = this.fb.group({
      objectColumnId: this.fb.control([], [Validators.required]),
      variantColumnId: this.fb.control(null, [Validators.required]),
    });
  }

  public mapObjectsToVariant() {
    this.markAsTouched(this.variantObjectMapping);

    if (!this.variantObjectMapping.valid) return true;

    this.variantsService
      .mapObjectsToVariant(this.variantObjectMapping.getRawValue())
      .pipe(take(1))
      .subscribe(_ => {
        this._canILeave = true;
        this.toastr.success('The mapping was successful!');
        this.router.navigate(['/xml-data-maintenance/configurations-variants']);
      });
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  public resetForm() {
    this.variantObjectMapping.reset({ objectColumnId: [], variantColumnId: null });
    this.variantObjectMapping.controls.variantColumnId.enable({ emitEvent: false });
    this.variantObjectMapping.controls.variantColumnId.setValue([]);
    this.variantObjectMapping.controls.objectColumnId.disable();
    this.printSelectedVariant = '';
  }

  public printVariant(variant) {
    if (variant.value) {
      if (this.variantObjectMapping.controls.objectColumnId.disabled) {
        this.variantObjectMapping.controls.objectColumnId.enable();
      }
      this.printSelectedVariant = variant.option.searchValue;
    } else if (!variant.automaticallyChanged) {
      this.variantObjectMapping.controls.objectColumnId.disable();
      this.printSelectedVariant = '';
    }
  }

  public canILeave() {
    return this._canILeave;
  }
}
