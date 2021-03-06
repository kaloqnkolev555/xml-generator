import { Component, OnInit } from '@angular/core';
import { ICreateObjectOutput } from '../../../interfaces/create-object-output.interface';
import { CreateObjectService } from '../../../create-object.service';
import { CreateObjectSteps } from '../../../objects-shared-module/resources';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-object-overview',
  templateUrl: './object-overview.component.html',
  styleUrls: ['./object-overview.component.scss'],
})
export class ObjectOverviewComponent implements OnInit {
  public backButtonNavigateUrl = `/xml-data-maintenance/objects/create/${CreateObjectSteps.CG_VARIANT_MAPPING}`;

  public dataSource: ICreateObjectOutput;

  public areasAndColumns = [];
  public variants = [];
  public constraints = [];

  constructor(
    private readonly createObjectService: CreateObjectService,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.dataSource = this.createObjectService.getAllData();
    this.constraints = this.dataSource.cgMetaConstraintsArea.constraints;
    this.variants = this.dataSource.cgMetaVariantToObject.variants;

    this.areasAndColumns = this.dataSource.mappedColumns.reduce((acc, value) => {
      acc.push({ areaName: value.areaName, mappedColumns: value.mappedColumns.map(el => el.columnName) });
      return acc;
    }, []);
  }

  public onFinishClick() {
    this.createObjectService.actionEmitter.emit();
  }

  public backButtonClick() {
    this.router.navigate([`./${CreateObjectSteps.CG_VARIANT_MAPPING}`], { relativeTo: this.route.parent });
  }
}
