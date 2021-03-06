import { Component, OnChanges, Input, SimpleChanges } from '@angular/core';
import { IcgMetaObjectOutput } from '../../../interfaces/create-object-output.interface';

@Component({
  selector: 'app-object-overview-object-info',
  templateUrl: './object-overview-object-info.component.html',
  styleUrls: ['./object-overview-object-info.component.scss']
})
export class ObjectOverviewObjectInfoComponent implements OnChanges {

  @Input() cgMetaObjectInfo: IcgMetaObjectOutput;

  public firstColumnData = [];
  public secondColumnData = [];

  ngOnChanges(changes: SimpleChanges) {
    if (!!this.cgMetaObjectInfo) {
      this.firstColumnData = [
        { label: 'Name:', value: this.cgMetaObjectInfo.cgMetaObjectName },
        { label: 'Description', value: this.cgMetaObjectInfo.description },
        { label: 'is_default:', value: this.cgMetaObjectInfo.isDefault ? 'YES' : 'NO' },
      ];
      if (this.cgMetaObjectInfo.isFooter) {
        this.secondColumnData = [
          { label: 'Type:', value: 'Footer Object' },
          { label: 'Header Object:', value: this.cgMetaObjectInfo.headerObjectName },
          { label: 'Footer Table:', value: this.cgMetaObjectInfo.mapCgMetaTableName },
          { label: 'Footer File Name:', value: this.cgMetaObjectInfo.fileName },
          { label: 'hashtotalfield:', value: this.cgMetaObjectInfo.hashTotalField },
        ];
      } else {
        this.secondColumnData = [
          { label: 'Type:', value: 'Generic or Header Object' },
          { label: 'Group:', value: `${this.cgMetaObjectInfo.mapCgMetaGroup.groupId} - ${this.cgMetaObjectInfo.mapCgMetaGroup.groupLabel}`  },
          { label: 'Table:', value: this.cgMetaObjectInfo.mapCgMetaTableName },
        ];
      }
    }
  }
}
