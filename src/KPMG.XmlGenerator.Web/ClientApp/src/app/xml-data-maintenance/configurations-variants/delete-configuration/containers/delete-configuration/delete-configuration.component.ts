import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IConfigurations } from '@app/common/interfaces';
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
  selector: 'app-delete-configuration',
  templateUrl: './delete-configuration.component.html',
  styleUrls: ['./delete-configuration.component.scss'],
})
export class DeleteConfigurationComponent implements OnInit, ICanILeave {
  constructor(
    private readonly fb: FormBuilder,
    private readonly confirmationPopUp: ConfirmationPopUpService,
    private readonly route: ActivatedRoute,
    private readonly configurationService: VariantsService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  private _canILeave = false;
  public deleteConfigurationForm: FormGroup;
  private unsubscribe = new Subject();
  public mainTitle = 'Delete Configuration(s)';
  public configurations: IConfigurations[] = [];
  public collectConfigurationsCTR = new FormControl([], [Validators.required]);
  private _selectedConfigurations: IConfigurations[] = [];
  private _warningDescription = '';

  public delete_configuration_errors: IErrorSet = {
    templateCgMetaConfigurationIdColumn: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit() {
    this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      this.configurations = data.configurations;
    });
    this.buildTheForm();
  }

  private buildTheForm() {
    this.deleteConfigurationForm = this.fb.group({
      updateOn: 'submit',
    });
  }

  private printConfigurationNames(): void {
    this.collectConfigurationsCTR.value.forEach(selectedId => {
      this._selectedConfigurations.push(this.configurations.find(x => x.id === selectedId));
    });
  }

  public deleteConfiguration(): void {
    this.deleteConfigurationForm.addControl('templateCgMetaConfigurationIdColumn', this.collectConfigurationsCTR);
    this.markAsTouched(this.deleteConfigurationForm);
    if (!this.deleteConfigurationForm.valid) return;

    this.printConfigurationNames();
    if (this._selectedConfigurations.length > 10) {
      this._warningDescription = 'Warning! ' + this._selectedConfigurations.length + ' configurations are selected.';
      this._selectedConfigurations = [];
    } else {
      this._warningDescription = 'Warning! The following configuration(s) is selected';
    }
    this.confirmationPopUp
      .open({
        title: 'Are you sure you want to continue?',
        description:
          'By clicking Delete you confirm that all the selected Configurations (and the associated variant mappings) will be permanently deleted from the database. The variants themselves will remain.',
        warningDescription: this._warningDescription,
        selectedConfigurations: this._selectedConfigurations,
      })
      .subscribe(onClose => {
        if (onClose) {
          this.configurationService
            .deleteConfiguration(this.collectConfigurationsCTR.value)
            .pipe(take(1))
            .subscribe(_ => {
              this._canILeave = true;
              this.deleteConfigurationForm.reset();
              this.toastr.success('Successfully deleted configuration(s)!');
              this.router.navigate(['/xml-data-maintenance/configurations-variants']);
            });
        } else {
          this._selectedConfigurations = [];
        }
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
