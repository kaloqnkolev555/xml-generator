import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Inject } from '@angular/core';
import { IMapObjectsToArea } from '../../interfaces/map-objects-to-area.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { take, filter, takeUntil, switchMap } from 'rxjs/operators';
import { IMapObjectToAreasComponentResolve } from '../../map-objects-to-area-routing.module';
import { IArea, IObject } from '../../../../../common/interfaces';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { MapObjectsToAreaService } from '../../map-objects-to-area.service';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms/mark-all-as-touched.forms';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { ToastrService } from 'ngx-toastr';

interface IMapOfAreaToObjects {
  [key: string]: Set<string>;
}

@Component({
  selector: 'app-map-objects-to-area',
  templateUrl: './map-objects-to-area.component.html',
  styleUrls: ['./map-objects-to-area.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MapObjectsToAreaComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();
  private _canILeave = false;

  public mainTitle = 'Map Objects to Area';
  public mapObjectsToAreaForm: FormGroup;

  public mapObjectsToAreas: IMapObjectsToArea[];
  public mapOfAreaToObjects: IMapOfAreaToObjects = {};

  public areas: IArea[];
  public objects: IObject[];

  public printSelectedArea = '';

  public map_objects_to_errors: IErrorSet = {
    objectColumnId: [{ type: 'required', message: 'Mandatory field' }],
    areaColumnId: [{ type: 'required', message: 'Mandatory field' }],
  };

  constructor(
    private readonly route: ActivatedRoute,
    private readonly fb: FormBuilder,
    private readonly mapObjectsToAreaService: MapObjectsToAreaService,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}

  public ngOnInit(): void {
    this.route.data
      .pipe(
        take(1),
        takeUntil(this.unsubscribe)
      )
      .subscribe((result: IMapObjectToAreasComponentResolve) => {
        this.objects = result.objects.sort((a, b) => (a.cgMetaObjectName > b.cgMetaObjectName ? 1 : -1));
        this.areas = result.areas.sort((a, b) => (a.areaName > b.areaName ? 1 : -1));
      });

    this.buildTheForm();

    const { areaColumnId: areasCTR, objectColumnId: objectsCTR } = this.mapObjectsToAreaForm.controls;

    areasCTR.valueChanges
      .pipe(
        filter(value => value !== null),
        switchMap(value => this.mapObjectsToAreaService.getAreaToObject(value)),
        takeUntil(this.unsubscribe)
      )
      .subscribe(value => {
        objectsCTR.setValue(value.objectColumnId, { emitEvent: false });
      });

    objectsCTR.valueChanges.pipe(takeUntil(this.unsubscribe)).subscribe(_ => {
      if (areasCTR.value !== null && !areasCTR.disabled && objectsCTR.dirty)
        areasCTR.disable({
          emitEvent: false,
        });
    });
    this.mapObjectsToAreaForm.controls.objectColumnId.disable();
  }

  private buildTheForm() {
    this.mapObjectsToAreaForm = this.fb.group({
      objectColumnId: this.fb.control([], [Validators.required]),
      areaColumnId: this.fb.control(null, [Validators.required]),
    });
  }

  public mapObjectsToArea() {
    this.markAsTouched(this.mapObjectsToAreaForm);

    if (!this.mapObjectsToAreaForm.valid) return true;

    this.mapObjectsToAreaService
      .mapObjectsToArea(this.mapObjectsToAreaForm.getRawValue())
      .pipe(take(1))
      .subscribe(_ => {
        this._canILeave = true;
        this.toastr.success('The mapping was successful!');
        this.router.navigate(['/xml-data-maintenance/areas']);
      });
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  public resetForm() {
    this.mapObjectsToAreaForm.reset({ objectColumnId: [], areaColumnId: null });
    this.mapObjectsToAreaForm.controls.areaColumnId.enable({ emitEvent: false });
    this.mapObjectsToAreaForm.controls.areaColumnId.setValue([]);
    this.mapObjectsToAreaForm.controls.objectColumnId.disable();
    this.printSelectedArea = '';
  }

  public printArea(area) {
    if (area.value) {
      if (this.mapObjectsToAreaForm.controls.objectColumnId.disabled) {
        this.mapObjectsToAreaForm.controls.objectColumnId.enable();
      }
      this.printSelectedArea = area.option.searchValue;
    } else if (!area.automaticallyChanged) {
      this.mapObjectsToAreaForm.controls.objectColumnId.disable();
      this.printSelectedArea = '';
    }
  }

  public canILeave() {
    return this._canILeave;
  }
}
