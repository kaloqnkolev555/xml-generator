import { Component, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { IColumn, IAreaForRefTable } from '@app/common/interfaces';
import { ColumnService } from '@app/xml-data-maintenance/column/column.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-cg-meta-column-element',
  templateUrl: './cg-meta-column-element.component.html',
  styleUrls: ['./cg-meta-column-element.component.scss'],
})
export class CgMetaColumnElementComponent {
  @Input() public group: FormGroup;
  @Input() public columns: IColumn[] = [];
  @Input() public tableName = '';
  @Input() public refAreas: IAreaForRefTable[] = [];

  public refAreaCTR = new FormControl('');

  public meta_column_errors: IErrorSet = {
    mappedColumns: [
      { type: 'required', message: 'Mandatory field' },
      { type: 'atLeastOneKeyColumn', message: 'At least one key column should be selected' },
    ],
  };

  constructor(private columnService: ColumnService) {}

  public mapColumns() {
    if (this.isCopyButtonValid()) return false;

    const value = this.refAreaCTR.value;

    this.columnService
      .getColumnsByObjectNameAreaName(value.cgMetaObjectName, value.area.areaName)
      .pipe(take(1))
      .subscribe(result => this.updateCheckedColumn(result));
  }

  private updateCheckedColumn(newData: IColumn[]) {
    const theColumns = this.columns.filter(column =>
      newData.find(
        el => el.columnName === column.columnName // && el.keyFlag === column.keyFlag && el.tableName === column.tableName
      )
    );

    this.group.patchValue(
      {
        mappedColumns: theColumns,
      },
      { emitEvent: false }
    );
  }

  public columnOptionTextBuilder(data: IColumn) {
    return data.keyFlag ? `${data.columnName} (KEY)` : data.columnName;
  }

  public isCopyButtonValid() {
    return this.refAreaCTR.value === '' || !this.refAreaCTR.value;
  }
}
