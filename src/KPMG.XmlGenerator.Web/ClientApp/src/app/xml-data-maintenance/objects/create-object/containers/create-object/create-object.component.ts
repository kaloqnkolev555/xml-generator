import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter, switchMap, takeUntil, catchError, take } from 'rxjs/operators';
import { Event } from '@angular/router';
import { IBreadcrumb } from '@app/common/secondary-header';
import {
  BREAD_CRUMBS_BUILDER,
  BreadCrumbsBuilder,
} from '@app/xml-data-maintenance/objects/objects-shared-module/resources/bread-crumbs-builder';
import { CreateObjectService } from '@app/xml-data-maintenance/objects/create-object.service';
import { ObjectsService } from '@app/xml-data-maintenance/objects/objects.service';
import { Subject, Observable, throwError, empty, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';

@Component({
  selector: 'app-create-object',
  templateUrl: './create-object.component.html',
  styleUrls: ['./create-object.component.scss'],
})
export class CreateObjectComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();

  public title = 'Create New Object';
  public breadcrumbs: IBreadcrumb[] = [];
  public stepTitle = '';

  constructor(
    private readonly router: Router,
    @Inject(BREAD_CRUMBS_BUILDER)
    private readonly breadCrumbsBuilder: BreadCrumbsBuilder,
    private readonly createObjectService: CreateObjectService,
    private readonly toastr: ToastrService,
    private readonly objectService: ObjectsService,
    private readonly confirmationPopUp: ConfirmationPopUpService
  ) {}

  ngOnInit() {
    this.updateBreadCrumbs(this.router.url);
    this.updateStepTitle();

    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe((event: Event) => {
      this.updateBreadCrumbs(this.router.url);
      this.updateStepTitle();
    });

    this.createObjectService.actionEmitter
      .pipe(
        switchMap(() =>
          this.confirmationPopUp.open({
            title: 'Create New Object',
            description: 'With finalizing this object, it will become available in the database.',
          })
        ),
        filter(result => result),
        takeUntil(this.unsubscribe)
      )
      .subscribe(() => this.createObject());
  }

  private createObject() {
    this.objectService
      .createObject(this.createObjectService.getAllData())
      .pipe(take(1))
      .subscribe(
        result => {
          this.toastr.success('You have created a new object!');
          this.router.navigate(['/xml-data-maintenance/objects']);
        },
        error => {
          this.toastr.error('Something went wrong. Object cannot be created.');
        }
      );
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
