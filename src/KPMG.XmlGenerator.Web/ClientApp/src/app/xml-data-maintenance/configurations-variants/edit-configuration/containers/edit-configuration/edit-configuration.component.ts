import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '../../../../../common/forms/mark-all-as-touched.forms';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';
import { take } from 'rxjs/operators';
import { IConfigurations } from '../../../../../common/interfaces/configurations.interface';
import { VariantsService } from '../../../../configurations-variants/configurations-variants.service';
import { existingPropertyValidator } from '../../../../../common/form-validators/existing-property.validator';

const CONFIGURATION_NAME_MAX_LENGTH = 70;

@Component({
  selector: 'app-edit-configuration',
  templateUrl: './edit-configuration.component.html',
  styleUrls: ['./edit-configuration.component.scss'],
})
export class EditConfigurationComponent implements OnInit {
  private _canILeave = false;

  public mainTitle = 'Edit Configuration Name';
  public configurations: IConfigurations[] = [];

  public editConfigurationForm: FormGroup;
  public configurationsCTR = new FormControl(null, [Validators.required]);
  public configurationCTR: FormControl = new FormControl();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly variantsService: VariantsService,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  public edit_configurations_error: IErrorSet = {
    configurationName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${CONFIGURATION_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-configurationName', message: 'Please enter unique name' },
    ],
    id: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit(): void {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.configurations = data.configurations;
    });

    this.buildTheForm();
  }

  private buildTheForm(): void {
    this.configurationCTR = this.fb.control(null, [
      Validators.required,
      Validators.maxLength(CONFIGURATION_NAME_MAX_LENGTH),
      existingPropertyValidator(this.configurations, 'configurationName'),
    ]);
    this.editConfigurationForm = this.fb.group(
      {
        configurationName: this.configurationCTR,
        id: this.configurationsCTR,
        versionId: this.fb.control(1), // TODO
      },
      { updateOn: 'submit' }
    );
  }

  public editConfiguration(): void {
    this.markAsTouched(this.editConfigurationForm);

    if (!this.editConfigurationForm.valid) return;

    this.variantsService
      .editConfiguration(this.editConfigurationForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this.toastr.success('You have updated the configuration!');
        this._canILeave = true;
        this.router.navigate(['/xml-data-maintenance/configurations-variants']);
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
