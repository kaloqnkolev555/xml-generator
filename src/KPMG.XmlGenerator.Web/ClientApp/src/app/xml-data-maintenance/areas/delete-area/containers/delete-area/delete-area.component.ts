import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IArea } from '@app/common/interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { take, takeUntil } from 'rxjs/operators';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { Subject } from 'rxjs';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';
import { ICanILeave } from '../../../../../common/interfaces/can-i-leave.interface';
import { AreasService } from '../../../../../xml-data-maintenance/areas/areas.service';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';

@Component({
  selector: 'app-delete-area',
  templateUrl: './delete-area.component.html',
  styleUrls: ['./delete-area.component.scss'],
})
export class DeleteAreaComponent implements OnInit, ICanILeave {
  constructor(
    private readonly fb: FormBuilder,
    private readonly confirmationPopUp: ConfirmationPopUpService,
    private readonly route: ActivatedRoute,
    private readonly areaService: AreasService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  private _canILeave = false;
  public deleteAreaForm: FormGroup;
  private unsubscribe = new Subject();
  public mainTitle = 'Delete Area';
  public areas: IArea[] = [];
  public collectAreas = new FormControl();
  public collectAreasCTR = new FormControl([], [Validators.required]);
  private _selectedAreas: IArea[] = [];
  private _warningDescription = '';

  public delete_area_errors: IErrorSet = {
    templateCgMetaAreaIdColumn: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit() {
    this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      this.areas = data.areas;
    });
    this.buildTheForm();
  }

  private buildTheForm() {
    this.deleteAreaForm = this.fb.group({
      updateOn: 'submit',
    });
  }

  private printAreaNames(): void {
    this.collectAreasCTR.value.forEach(selectedId => {
      this._selectedAreas.push(this.areas.find(x => x.id === selectedId));
    });
  }
  public deleteArea(): void {
    this.deleteAreaForm.addControl('templateCgMetaAreaIdColumn', this.collectAreasCTR);
    this.markAsTouched(this.deleteAreaForm);
    if (!this.deleteAreaForm.valid) return;

    this.printAreaNames();
    if (this._selectedAreas.length > 10) {
      this._warningDescription = 'Warning! ' + this._selectedAreas.length + ' areas are selected.';
      this._selectedAreas = [];
    } else {
      this._warningDescription = 'Warning! The following area(s) is selected';
    }
    this.confirmationPopUp
      .open({
        title: 'Are you sure you want to continue?',
        description:
          'By clicking Delete you confirm that all the selected Areas (and the their associated information, e.g. object mappings, column mappings, constraint mappings, etc.) will be permanently deleted from the database.',
        warningDescription: this._warningDescription,
        selectedAreas: this._selectedAreas,
      })
      .subscribe(onClose => {
        if (onClose) {
          this.areaService
            .deleteArea(this.collectAreasCTR.value)
            .pipe(take(1))
            .subscribe(_ => {
              this._canILeave = true;
              this.deleteAreaForm.reset();
              this.toastr.success('Successfully deleted area(s)!');
              this.router.navigate(['/xml-data-maintenance/areas']);
            });
        } else {
          this._selectedAreas = [];
        }
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
