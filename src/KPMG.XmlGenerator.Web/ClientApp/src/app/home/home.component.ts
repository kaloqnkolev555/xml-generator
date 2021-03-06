import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap';
import { Subject, throwError } from 'rxjs';
import { takeUntil, catchError } from 'rxjs/operators';
import { ErrorJsonComponent } from '../shared/components/error-json/error-json.component';
import { LocalStorageService } from '../shared/services/local-storage.service';
import { ICgMetaVersion, IDbName, IDbScriptExecutionResult } from './home.models';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [':host(.modal-body-scrollable){max-height:calc(100vh - 200px);overflow-y:auto}'],
})
export class HomeComponent implements OnInit, OnDestroy {
  private unsubscribe = new Subject();

  public mainTitle = 'Connect';
  public dbSettingsForm: FormGroup;

  currentDatabaseId: string;

  public dbNames: IDbName[] = [];
  public selectedDb: IDbName = null;
  public cgMetaVersions: ICgMetaVersion[] = [];
  public getVersionsError: string = null;
  public applyScriptsResults: IDbScriptExecutionResult[] = [];

  @ViewChild('modalApplyAllSqlScriptsResults', { static: false }) modalApplyAllSqlScriptsResults: ModalDirective;
  @ViewChild('errorGetVersions', { static: false }) ctrlErrorJsonGetVersions: ErrorJsonComponent;

  constructor(
    private homeService: HomeService,
    private localStorageService: LocalStorageService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    let fcSelectDb = new FormControl(null, [Validators.required]);
    let fcSelectVersion = new FormControl(null, [Validators.required]);
    this.dbSettingsForm = new FormGroup({
      selectDb: fcSelectDb,
      selectVersion: fcSelectVersion,
    });
    fcSelectDb.valueChanges.forEach(dbId => this.handleConnectToDbChange(dbId));

    this.homeService
      .getDbNames()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(result => {
        this.dbNames = result;
        let db: IDbName = this.localStorageService.getDb();
        if (!!db && result.some(x => x.id === db.id)) {
          fcSelectDb.setValue(db, { emitEvent: true });
        }
      });
  }

  public runDbScripts() {
    if (confirm(`Please confirm you want to run all DB update scripts on database ${this.selectedDb.name}.`)) {
      this.homeService.applyAllSqlScripts().subscribe(result => {
        this.applyScriptsResults = result;
        this.handleConnectToDbChange(this.selectedDb);
        this.modalApplyAllSqlScriptsResults.show();
      });
    }
  }

  public submitForm() {
    this.localStorageService.setVersion(<ICgMetaVersion>this.dbSettingsForm.controls['selectVersion'].value);
    this.router.navigate(['xml-data-maintenance']);
  }

  private handleConnectToDbChange(db: IDbName) {
    const fcSelectVersion = this.dbSettingsForm.controls['selectVersion'];
    const previousDb: IDbName = this.localStorageService.getDb();
    this.localStorageService.setDb(db);
    this.selectedDb = this.dbNames.find(x => x.id === db.id);
    this.homeService
      .getVersions(db.id)
      .pipe(
        catchError(error => {
          this.cgMetaVersions = [];
          this.getVersionsError = JSON.stringify((<HttpErrorResponse>error).error);

          return throwError({ skipError: true });
        })
      )
      .subscribe(
        result => {
          this.getVersionsError = null;
          this.cgMetaVersions = result.map(v => {
            v.displayString = `${v.id} — ${v.versionName}`;
            return v;
          });
          const previousVersion = this.localStorageService.getVersion();
          if (!previousVersion || previousDb.id !== db.id || !result.some(v => v.id === previousVersion.id)) {
            fcSelectVersion.setValue(result[result.length - 1], { emitEvent: true });
          } else {
            fcSelectVersion.setValue(previousVersion, { emitEvent: true });
          }
        },
      );
  }

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
