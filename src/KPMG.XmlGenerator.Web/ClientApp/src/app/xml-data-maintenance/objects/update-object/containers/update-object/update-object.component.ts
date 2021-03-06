import { Component, OnDestroy, Inject, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import { IBreadcrumb } from '@app/common/secondary-header';
import {
  BreadCrumbsBuilder,
  BREAD_CRUMBS_BUILDER,
} from '@app/xml-data-maintenance/objects/objects-shared-module/resources/bread-crumbs-builder';
import { Router, NavigationEnd } from '@angular/router';
import { filter, switchMap, takeUntil } from 'rxjs/operators';
import { ObjectsService } from '@app/xml-data-maintenance/objects/objects.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-object',
  templateUrl: './update-object.component.html',
  styleUrls: ['./update-object.component.scss'],
})
export class UpdateObjectComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();

  public title = 'Update Object';
  public breadcrumbs: IBreadcrumb[] = [];
  public stepTitle = '';

  constructor(
    private readonly router: Router,
    @Inject(BREAD_CRUMBS_BUILDER)
    private readonly breadCrumbsBuilder: BreadCrumbsBuilder,
    private readonly createObjectService: CreateObjectService,
    private readonly objectService: ObjectsService,
    private readonly toastr: ToastrService,
  ) {}

  ngOnInit() {
    this.updateBreadCrumbs(this.router.url);
    this.updateStepTitle();

    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(event => {
      this.updateBreadCrumbs(this.router.url);
      this.updateStepTitle();
    });

    this.createObjectService.actionEmitter.pipe(
      switchMap(_ => {
        return this.objectService.createObject(this.createObjectService.getAllData())
      }),
      takeUntil(this.unsubscribe)
    ).subscribe(_ => {
      this.toastr.success('You have updated the object successfully!');
      this.router.navigate(['/xml-data-maintenance/objects']);
    })
  }

  private updateBreadCrumbs(url: string) {
    const step = url.split('/').slice(-1)[0];
    this.breadcrumbs = this.breadCrumbsBuilder(step);
  }

  private updateStepTitle() {
    if (this.breadcrumbs.length > 0) {
      this.stepTitle = this.breadcrumbs[this.breadcrumbs.length - 1].stepTitle;
    }
  }

  public ngOnDestroy(): void {
    this.createObjectService.resetState();
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
