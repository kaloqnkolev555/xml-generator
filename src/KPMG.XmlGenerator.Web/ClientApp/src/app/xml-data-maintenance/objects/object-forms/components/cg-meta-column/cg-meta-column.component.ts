import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import {
  IcgMetaObjectOutput,
  IAreaToColumn,
} from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { IDD03 } from '@app/common/interfaces/dd03.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IAreaForRefTable, IColumn } from '@app/common/interfaces';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms';
import { KeyColumnValidator, KEY_COLUMN_VALIDATOR } from '../../validations';
import { CreateObjectSteps } from '@app/xml-data-maintenance/objects/objects-shared-module/resources';
import * as _ from 'lodash';

@Component({
  selector: 'app-cg-meta-column',
  templateUrl: './cg-meta-column.component.html',
  styleUrls: ['./cg-meta-column.component.scss'],
})
export class CgMetaColumnComponent implements OnInit {
  public _canILeave = false;

  public cgMetaColumnForm: FormGroup;
  public elements: FormArray;

  public cgMetaObjectDTO: IcgMetaObjectOutput;
  public mappedColumnsData: IAreaToColumn[];

  public dd03lColumns: IDD03[] = [];
  public columns: IColumn[] = [];

  public tableName: string;
  public refAreas: IAreaForRefTable[] = [];

  constructor(
    private readonly fb: FormBuilder,
    private readonly createObjectService: CreateObjectService,
    private readonly route: ActivatedRoute,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    @Inject(KEY_COLUMN_VALIDATOR)
    private readonly keyColumnValidator: KeyColumnValidator,
    private readonly router: Router,
    private readonly ngZone: NgZone
  ) {}

  ngOnInit() {
    this.cgMetaObjectDTO = this.createObjectService.getData('cgMetaObjectDTO');
    this.mappedColumnsData = this.createObjectService.getData('mappedColumns');
    this.tableName = this.cgMetaObjectDTO.mapCgMetaTableName;

    this.route.data.pipe(take(1)).subscribe(data => {
      this.dd03lColumns = data.dd03lColumns;
      const areaTemplates = <IAreaForRefTable[]>data.refAreas;
      areaTemplates.forEach(t => { t.displayName = `${t.area.areaName} - ${t.cgMetaObjectName}`; });
      this.refAreas = areaTemplates;

      this.columns = this.dd03lColumns.map(el => ({
        columnName: el.fieldName,
        keyFlag: el.isKeyField,
        tableName: el.tableName,
      }));
    });

    this.buildTheForm();
  }

  public sizeEvent() {
    this.ngZone.runOutsideAngular(() =>
    setTimeout(() => {
      window.dispatchEvent(new Event('resize'));
    }, 0)
  );
  }

  private buildTheForm() {
    this.cgMetaColumnForm = this.fb.group({
      data: this.fb.array([]),
    });

    this.elements = this.cgMetaColumnForm.get('data') as FormArray;

    this.mappedColumnsData.forEach(el => {
      this.elements.push(
        this.createItem({
          id: el.id,
          versionId: el.versionId,
          areaName: el.areaName,
          mappedColumns:
            el.mappedColumns.length > 0
              ? el.mappedColumns
              : this.columns.filter(c => c.keyFlag),
        })
      );
    });
  }

  private createItem(data: IAreaToColumn): FormGroup {
    return this.fb.group({
      id: data.id,
      versionId: data.versionId,
      areaName: data.areaName,
      mappedColumns: this.fb.control(data.mappedColumns, [this.keyColumnValidator]),
    });
  }

  public nextStep() {
    this.markAsTouched(this.cgMetaColumnForm);
    if (!this.cgMetaColumnForm.valid) return;

    const stepData = this.cgMetaColumnForm.value.data;
    const isStepDifferent = this.createObjectService.isStepDifferent('mappedColumns', stepData);
    const isStepPassed = this.createObjectService.isStepPassed('mappedColumns');

    if (isStepDifferent && isStepPassed) {
      this.createObjectService.setData('mappedColumns', stepData, true);
    } else {
      this.createObjectService.setData('mappedColumns', stepData, false);
    }

    this._canILeave = true;
    this.router.navigate([`./${CreateObjectSteps.CG_CONSTRAINT}`], { relativeTo: this.route.parent });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_AREA_MAPPING}`], { relativeTo: this.route.parent });
  }
}
