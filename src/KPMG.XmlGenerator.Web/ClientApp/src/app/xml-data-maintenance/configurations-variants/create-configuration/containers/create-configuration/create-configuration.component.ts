import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { IVariants } from '@app/common/interfaces/variants.interface';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { FormBuilder, Validators, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VariantsService } from '@app/xml-data-maintenance/configurations-variants/configurations-variants.service';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { ICanILeave } from '@app/common/interfaces/can-i-leave.interface';
import { takeUntil, take } from 'rxjs/operators';
import { IConfigurations } from '@app/common/interfaces/configurations.interface';
import { existingPropertyValidator } from '@app/common/form-validators/existing-property.validator';

const CONFIGURATION_NAME_MAX_LENGTH = 70;

@Component({
  selector: 'app-create-configuration',
  templateUrl: './create-configuration.component.html',
  styleUrls: ['./create-configuration.component.scss'],
})
export class CreateConfigurationComponent implements OnInit, OnDestroy, ICanILeave {
  private _canILeave = false;
  private unsubscribe = new Subject();

  public createConfigurationForm: FormGroup;

  public mainTitle = 'Create New Configuration';
  public variants: IVariants[] = [];

  /* 
    It's hack that I'm not proud of. It's back-end decision.
    We fetch them all to check for uniqueness.
  */
  public configurations: IConfigurations[] = [];

  public mapMetaVariantIdColumnsCTR = new FormControl([], [Validators.required]);

  public create_configuration_errors: IErrorSet = {
    configurationName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${CONFIGURATION_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-configurationName', message: 'Please enter unique name' },
    ],
    mapMetaVariantIdColumns: [{ type: 'required', message: 'Mandatory field' }],
  };

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
      this.variants = data.variants;
      this.configurations = data.configurations; //It's hack that I'm not proud of. It's back-end decision.
    });

    this.buildTheForm();
  }

  private buildTheForm(): void {
    this.createConfigurationForm = this.fb.group(
      {
        configuration: this.fb.group({
          configurationName: this.fb.control('', [
            Validators.required,
            Validators.maxLength(CONFIGURATION_NAME_MAX_LENGTH),
            existingPropertyValidator(this.configurations, 'configurationName'),
          ]),
          versionId: 1, // TODO
        }),
        mapMetaVariantIdColumns: this.mapMetaVariantIdColumnsCTR,
      },
      {
        updateOn: 'submit',
      }
    );
  }

  public createConfiguration(): void {
    this.markAsTouched(this.createConfigurationForm);
    if (!this.createConfigurationForm.valid) return;
    this.variantService
      .createConfiguration(this.createConfigurationForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this._canILeave = true;
        this.toastr.success('You have created a new configuration!');
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
