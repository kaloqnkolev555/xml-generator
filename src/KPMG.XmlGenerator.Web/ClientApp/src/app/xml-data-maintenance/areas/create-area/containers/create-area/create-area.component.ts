import { Component, OnInit, Inject, OnDestroy, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { IObject, IArea } from '../../../../../common/interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { existingPropertyValidator } from '../../../../../common/form-validators/existing-property.validator';
import { AreasService } from '../../../../../xml-data-maintenance/areas/areas.service';
import { ICanILeave } from '../../../../../common/interfaces/can-i-leave.interface';
import { take, takeUntil } from 'rxjs/operators';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '../../../../../common/forms/mark-all-as-touched.forms';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { IErrorSet } from '../../../../../common/interfaces/error-set.interface';

const AREA_NAME_MAX_LENGTH = 70;

enum TabsName {
  NONE = 'None',
  EXISTING_AREA = 'Existing Area',
}

interface ITab {
  name: TabsName;
}

enum FormControls {
  AREA_NAME = 'areaName',
}

@Component({
  selector: 'app-create-area',
  templateUrl: './create-area.component.html',
  styleUrls: ['./create-area.component.scss'],
})
export class CreateAreaComponent implements OnInit, OnDestroy, ICanILeave {
  private _canILeave = false;
  private unsubscribe = new Subject();

  public createAreaForm: FormGroup;

  public tabsName = TabsName;
  public mainTitle = 'Create New Area';
  public objects: IObject[] = [];
  public areas: IArea[] = [];

  public selectAreaCTR = new FormControl(null, [Validators.required]);
  public selectedObjectsCTR = new FormControl([], [Validators.required]);

  public tabs: ITab[] = [
    {
      name: TabsName.NONE,
    },
    {
      name: TabsName.EXISTING_AREA,
    },
  ];

  public formControls = FormControls;

  public create_area_errors: IErrorSet = {
    areaName: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'maxlength', message: `Please fill in maximum ${AREA_NAME_MAX_LENGTH} symbols.` },
      { type: 'existing-areaName', message: 'Please enter unique name' },
    ],
    templateCgMetaAreaIdColumn: [{ type: 'required', message: 'Mandatory field' }],
    mapMetaObjctIdColumns: [{ type: 'required', message: 'Mandatory field' }],
  };

  public activeTab: ITab;

  @ViewChild('createAreaFormRef', { static: false })
  public createAreaFormRef: NgForm;

  constructor(
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute,
    private readonly areaService: AreasService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    // this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      // this.objects = data.objects;
      // this.areas = data.areas;
    // });
    this.objects = [];
    this.areas = [];

    this.buildTheForm();
    this.select(this.tabs[0]);
  }

  private buildTheForm(): void {
    this.createAreaForm = this.fb.group(
      {
        area: this.fb.group({
          areaName: this.fb.control('', [
            Validators.required,
            Validators.maxLength(AREA_NAME_MAX_LENGTH),
            existingPropertyValidator(this.areas, 'areaName'),
          ]),
          versionId: 1, // TODO
        }),
      },
      {
        updateOn: 'submit',
      }
    );
  }

  private addTemplateCgMetaAreaIdColumn(): void {
    this.createAreaForm.addControl('templateCgMetaAreaIdColumn', this.selectAreaCTR);
  }

  private removeTemplateCgMetaAreaIdColumn(): void {
    this.createAreaForm.removeControl('templateCgMetaAreaIdColumn');
  }

  private addMapMetaObjctIdColumns(): void {
    this.createAreaForm.addControl('mapMetaObjctIdColumns', this.selectedObjectsCTR);
  }

  private removeMapMetaObjctIdColumns(): void {
    this.createAreaForm.removeControl('mapMetaObjctIdColumns');
  }

  public select(tab: ITab): void {
    this.activeTab = tab;

    if (tab.name === TabsName.NONE) {
      this.removeTemplateCgMetaAreaIdColumn();
      this.addMapMetaObjctIdColumns();
    }

    if (tab.name === TabsName.EXISTING_AREA) {
      this.removeMapMetaObjctIdColumns();
      this.addTemplateCgMetaAreaIdColumn();
    }
  }

  public createArea(): void {
    this.markAsTouched(this.createAreaForm);

    if (!this.createAreaForm.valid) return;

    this.areaService
      .createArea(this.createAreaForm.value)
      .pipe(take(1))
      .subscribe(_ => {
        this._canILeave = true;
        this.toastr.success('You have created a new area!');
        this.router.navigate(['/xml-data-maintenance/areas']);
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
