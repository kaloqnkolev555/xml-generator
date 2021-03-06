import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IArea } from '@app/common/interfaces';
import { take } from 'rxjs/operators';
import { Validators, FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { AreasService } from '@app/xml-data-maintenance/areas/areas.service';
import { ToastrService } from 'ngx-toastr';
import { existingPropertyValidator } from '@app/common/form-validators/existing-property.validator';

const AREA_NAME_MAX_LENGTH = 70;

@Component({
  selector: 'app-edit-area',
  templateUrl: './edit-area.component.html',
  styleUrls: ['./edit-area.component.scss'],
})
export class EditAreaComponent implements OnInit {
  private _canILeave = false;

  public mainTitle = 'Edit Area Name';
  public areas: IArea[] = [];

  public editAreaForm: FormGroup;
  public areasCTR = new FormControl(null, [Validators.required]);
  public areaCTR: FormControl = new FormControl();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly areasService: AreasService,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  public edit_areas_error: IErrorSet = {
    areaName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${AREA_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-areaName', message: 'Please enter unique name' },
    ],
    id: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit(): void {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.areas = data.areas;
    });

    this.buildTheForm();
  }

  private buildTheForm(): void {
    this.areaCTR = this.fb.control(null, [
      Validators.required,
      Validators.maxLength(AREA_NAME_MAX_LENGTH),
      existingPropertyValidator(this.areas, 'areaName'),
    ]);

    this.editAreaForm = this.fb.group(
      {
        areaName: this.areaCTR,
        id: this.areasCTR,
        versionId: this.fb.control(1), // TODO
      },
      { updateOn: 'submit' }
    );
  }

  public editArea(): void {
    this.markAsTouched(this.editAreaForm);

    if (!this.editAreaForm.valid) return;

    this.areasService
      .editArea(this.editAreaForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this.toastr.success('You have updated the area!');
        this._canILeave = true;
        this.router.navigate(['/xml-data-maintenance/areas']);
      });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }
}
