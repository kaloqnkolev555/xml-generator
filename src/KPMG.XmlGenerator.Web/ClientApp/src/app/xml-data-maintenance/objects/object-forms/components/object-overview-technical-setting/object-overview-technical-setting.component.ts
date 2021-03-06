import { Component, OnChanges, SimpleChanges, Input } from '@angular/core';
import { IcgMetaTechnicalSetting } from '../../../interfaces/create-object-output.interface';

@Component({
  selector: 'app-object-overview-technical-setting',
  templateUrl: './object-overview-technical-setting.component.html',
  styleUrls: ['./object-overview-technical-setting.component.scss']
})
export class ObjectOverviewTechnicalSettingComponent implements OnChanges {
  @Input() cgMetaTechnicalSetting: IcgMetaTechnicalSetting;

  public firstColumnData = [];
  public secondColumnData = [];

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    if (!!this.cgMetaTechnicalSetting) {
      this.firstColumnData = [
        { label: 'Extraction Logic:', value: this.cgMetaTechnicalSetting.cgMetaExtractionLogic.cgMetaExtractionLogicName },
        { label: 'Helper Table Name:', value: this.getDisplayString(this.cgMetaTechnicalSetting.mapCgMetaHelperTableName) },
        { label: 'DayByDay:', value: this.getDisplayString(this.cgMetaTechnicalSetting.dayByDay) },
        { label: 'Days per Loop:', value: this.getDisplayString(this.cgMetaTechnicalSetting.daysPerLoop) },
        { label: 'NrObject:', value: this.getDisplayString(this.cgMetaTechnicalSetting.mapNrObject) },
        { label: 'NrField:', value: this.getDisplayString(this.cgMetaTechnicalSetting.mapNrField) },
        { label: 'Use NrMin / NrMax:', value: this.getBooleanDisplayString(this.cgMetaTechnicalSetting.useNrMinMax) },
        { label: 'Parallel:', value: this.getBooleanDisplayString(this.cgMetaTechnicalSetting.isParallel) },
      ];
      this.secondColumnData = [
        { label: 'pkgSize:', value: this.cgMetaTechnicalSetting.pkgSize },
        { label: 'pkgSize2:', value: this.cgMetaTechnicalSetting.pkgSize2 },
        { label: 'xFilename:', value: this.getDisplayString(this.cgMetaTechnicalSetting.xFilename) },
        { label: 'hashtotalfield:', value: this.getDisplayString(this.cgMetaTechnicalSetting.hashTotalField) },
        { label: 'is_default_setting:', value: this.getBooleanDisplayString(this.cgMetaTechnicalSetting.isDefault) },
        { label: 'docNbr:', value: this.getDisplayString(this.cgMetaTechnicalSetting.docNbr) },
        { label: 'loopAt:', value: this.getDisplayString(this.cgMetaTechnicalSetting.loopAt) },
      ];
    }
  }

  private getDisplayString(value: string | number): string {
    if (value === 0 || value === '0') {
      return value.toString();
    }

    if (!!value) {
      return '' + value;
    }

    return '-';
  }

  private getBooleanDisplayString(value: boolean): string {
    return value ? 'YES' : 'NO';
  }
}
