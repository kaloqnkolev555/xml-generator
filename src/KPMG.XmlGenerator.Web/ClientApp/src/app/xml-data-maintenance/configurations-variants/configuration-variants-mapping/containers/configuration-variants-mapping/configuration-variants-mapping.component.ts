import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IVariants } from '@app/common/interfaces/variants.interface';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { VariantsService } from '@app/xml-data-maintenance/configurations-variants/configurations-variants.service';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { ToastrService } from 'ngx-toastr';
import { take, filter, switchMap, takeUntil } from 'rxjs/operators';
import { IConfigurations } from '@app/common/interfaces/configurations.interface';

@Component({
  selector: 'app-configuration-variants-mapping',
  templateUrl: './configuration-variants-mapping.component.html',
  styleUrls: ['./configuration-variants-mapping.component.scss'],
})
export class ConfigurationVariantsMappingComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();
  private _canILeave = false;

  public mainTitle = 'Map Variants to Configuration';
  public configurationVariantsMapping: FormGroup;

  public variants: IVariants[];
  public configurations: IConfigurations[] = [];

  public printSelectedConfiguration = '';

  public map_objects_to_errors: IErrorSet = {
    variantColumnId: [{ type: 'required', message: 'Mandatory field' }],
    configurationColumnId: [{ type: 'required', message: 'Mandatory field' }],
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
      this.variants = result.variants;
      this.configurations = result.configurations;
    });

    this.buildTheForm();

    const {
      configurationColumnId: configurationsCTR,
      variantColumnId: variantsCTR,
    } = this.configurationVariantsMapping.controls;

    configurationsCTR.valueChanges
      .pipe(
        filter(value => value !== null),
        switchMap(value => this.variantsService.getConfigurationToVariant(value)),
        takeUntil(this.unsubscribe)
      )
      .subscribe(value => {
        variantsCTR.setValue(value.variantColumnId, { emitEvent: false });
      });

    variantsCTR.valueChanges.pipe(takeUntil(this.unsubscribe)).subscribe(_ => {
      if (configurationsCTR.value !== null && !configurationsCTR.disabled && variantsCTR.dirty)
        configurationsCTR.disable({
          emitEvent: false,
        });
    });
    this.configurationVariantsMapping.controls.variantColumnId.disable();
  }

  private buildTheForm() {
    this.configurationVariantsMapping = this.fb.group({
      configurationColumnId: this.fb.control(null, [Validators.required]),
      variantColumnId: this.fb.control([], [Validators.required]),
    });
  }

  public mapConfigurationToVariants() {
    this.markAsTouched(this.configurationVariantsMapping);

    if (!this.configurationVariantsMapping.valid) return true;

    this.variantsService
      .mapConfigurationToVariant(this.configurationVariantsMapping.getRawValue())
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
    this.configurationVariantsMapping.reset({ variantColumnId: [], configurationColumnId: null });
    this.configurationVariantsMapping.controls.configurationColumnId.enable({ emitEvent: false });
    this.configurationVariantsMapping.controls.configurationColumnId.setValue([]);
    this.configurationVariantsMapping.controls.variantColumnId.disable();
    this.printSelectedConfiguration = '';
  }

  public printVariant(configuration) {
    if (configuration.value) {
      if (this.configurationVariantsMapping.controls.variantColumnId.disabled) {
        this.configurationVariantsMapping.controls.variantColumnId.enable();
      }
      this.printSelectedConfiguration = configuration.option.searchValue;
    } else if (!configuration.automaticallyChanged) {
      this.configurationVariantsMapping.controls.variantColumnId.setValue([]);
      this.configurationVariantsMapping.controls.variantColumnId.disable();
      this.printSelectedConfiguration = '';
    }
  }

  public canILeave() {
    return this._canILeave;
  }
}
