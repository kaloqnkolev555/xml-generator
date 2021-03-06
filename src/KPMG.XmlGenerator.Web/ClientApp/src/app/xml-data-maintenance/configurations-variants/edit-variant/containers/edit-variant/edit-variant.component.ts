import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';
import { take } from 'rxjs/operators';
import { IVariants } from '../../../../../common/interfaces/variants.interface';
import { VariantsService } from '@app/xml-data-maintenance/configurations-variants/configurations-variants.service';
import { existingPropertyValidator } from '@app/common/form-validators/existing-property.validator';

const VARIANT_NAME_MAX_LENGTH = 70;

@Component({
  selector: 'app-edit-variant',
  templateUrl: './edit-variant.component.html',
  styleUrls: ['./edit-variant.component.scss'],
})
export class EditVariantComponent implements OnInit {
  private _canILeave = false;

  public mainTitle = 'Edit Variant Name';
  public variants: IVariants[] = [];

  public editVariantForm: FormGroup;
  public variantsCTR = new FormControl(null, [Validators.required]);
  public variantCTR: FormControl = new FormControl();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly variantsService: VariantsService,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  public edit_variants_error: IErrorSet = {
    variantName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${VARIANT_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-variantName', message: 'Please enter unique name' },
    ],
    id: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit(): void {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.variants = data.variants;
    });

    this.buildTheForm();
  }

  private buildTheForm(): void {
    this.variantCTR = this.fb.control(null, [
      Validators.required,
      Validators.maxLength(VARIANT_NAME_MAX_LENGTH),
      existingPropertyValidator(this.variants, 'variantName'),
    ]),

    this.editVariantForm = this.fb.group(
      {
        variantName: this.variantCTR,
        id: this.variantsCTR,
        versionId: this.fb.control(1), // TODO
      },
      { updateOn: 'submit' }
    );
  }

  public editVariant(): void {
    this.markAsTouched(this.editVariantForm);

    if (!this.editVariantForm.valid) return;

    this.variantsService
      .editVariant(this.editVariantForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this.toastr.success('You have updated the variant!');
        this._canILeave = true;
        this.router.navigate(['/xml-data-maintenance/configurations-variants']);
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
