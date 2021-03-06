import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IVariants } from '@app/common/interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { take, takeUntil } from 'rxjs/operators';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { Subject } from 'rxjs';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';
import { ICanILeave } from '../../../../../common/interfaces/can-i-leave.interface';
import { VariantsService } from '../../../../../xml-data-maintenance/configurations-variants/configurations-variants.service';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';

@Component({
  selector: 'app-delete-variant',
  templateUrl: './delete-variant.component.html',
  styleUrls: ['./delete-variant.component.scss'],
})
export class DeleteVariantComponent implements OnInit, ICanILeave {
  constructor(
    private readonly fb: FormBuilder,
    private readonly confirmationPopUp: ConfirmationPopUpService,
    private readonly route: ActivatedRoute,
    private readonly variantService: VariantsService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  private _canILeave = false;
  public deleteVariantForm: FormGroup;
  private unsubscribe = new Subject();
  public mainTitle = 'Delete Variant(s)';
  public variants: IVariants[] = [];
  public collectVariantsCTR = new FormControl([], [Validators.required]);
  private _selectedVariants: IVariants[] = [];
  private _warningDescription = '';

  public delete_variant_errors: IErrorSet = {
    templateCgMetaVariantIdColumn: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit() {
    this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      this.variants = data.variants;
    });
    this.buildTheForm();
  }

  private buildTheForm() {
    this.deleteVariantForm = this.fb.group({
      updateOn: 'submit',
    });
  }

  private printVariantNames(): void {
    this.collectVariantsCTR.value.forEach(selectedId => {
      this._selectedVariants.push(this.variants.find(x => x.id === selectedId));
    });
  }

  public deleteVariant(): void {
    this.deleteVariantForm.addControl('templateCgMetaVariantIdColumn', this.collectVariantsCTR);
    this.markAsTouched(this.deleteVariantForm);
    if (!this.deleteVariantForm.valid) return;

    this.printVariantNames();
    if (this._selectedVariants.length > 10) {
      this._warningDescription = 'Warning! ' + this._selectedVariants.length + ' variants are selected.';
      this._selectedVariants = [];
    } else {
      this._warningDescription = 'Warning! The following variant(s) is selected';
    }
    this.confirmationPopUp
      .open({
        title: 'Are you sure you want to continue?',
        description:
          'By clicking Delete you confirm that all the selected Variants (and the associated mappings to their configurations and objects) will be permanently deleted from the database.',
        warningDescription: this._warningDescription,
        selectedVariants: this._selectedVariants,
      })
      .subscribe(onClose => {
        if (onClose) {
          this.variantService
            .deleteVariant(this.collectVariantsCTR.value)
            .pipe(take(1))
            .subscribe(_ => {
              this._canILeave = true;
              this.deleteVariantForm.reset();
              this.toastr.success('Successfully deleted variant(s)!');
              this.router.navigate(['/xml-data-maintenance/configurations-variants']);
            });
        } else {
          this._selectedVariants = [];
        }
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
