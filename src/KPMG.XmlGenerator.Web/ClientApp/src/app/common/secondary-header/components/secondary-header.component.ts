import { Component, Input } from '@angular/core';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { IDbName, ICgMetaVersion } from '../../../home/home.models';
import { Router, ActivatedRoute } from '@angular/router';

export interface IBreadcrumb {
  stepTitle: string;
  step: number | string;
  label: string;
  url: string;
}

@Component({
  selector: 'app-secondary-header',
  templateUrl: './secondary-header.component.html',
  styleUrls: ['./secondary-header.component.scss'],
})
export class SecondaryHeaderComponent {
  @Input() mainTitle = '';
  @Input() plainText = '';
  @Input() stepTitle = '';
  @Input() breadcrumbs?: IBreadcrumb[];
  public db: IDbName;
  public version: ICgMetaVersion;

  constructor(
    private localStorageService: LocalStorageService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {
    this.db = this.localStorageService.getDb();
    this.version = this.localStorageService.getVersion();
  }

  public navigateRelatively(urlArr: []) {
    this.router.navigate(urlArr, { relativeTo: this.route.parent });
  }
}
