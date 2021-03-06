import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { IcgMetaObjectOutput } from '@app/xml-data-maintenance/objects/interfaces/create-object-output.interface';
import { takeUntil, take } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IErrorSet } from '@app/common/interfaces/error-set.interface';
import { MARK_CONTROLS_AS_TOUCHED, MarkAllAsTouched } from '@app/common/forms';
import { ConfirmationPopUpService } from '@app/common/confirmation-popup/components/confirmation-popup.service';
import { ToastrService } from 'ngx-toastr';
import { ObjectsService } from '@app/xml-data-maintenance/objects/objects.service';

@Component({
  selector: 'app-delete-object',
  templateUrl: './delete-object.component.html',
  styleUrls: ['./delete-object.component.scss'],
})
export class DeleteObjectComponent implements OnInit {
  constructor(
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly confirmationPopUp: ConfirmationPopUpService,
    private readonly toastr: ToastrService,
    private readonly router: Router,
    private readonly objectsService: ObjectsService
  ) {}

  mainTitle = 'Delete Object';
  private unsubscribe = new Subject();
  public objects: IcgMetaObjectOutput[] = [];
  public deleteForm: FormGroup;
  private _selectedObjects: IcgMetaObjectOutput[] = [];
  private _canILeave = false;
  private _warningDescription = '';

  public delete_object_errors: IErrorSet = {
    objectsControl: [{ type: 'required', message: 'Mandatory field' }],
  };

  ngOnInit() {
    this.route.data.pipe(takeUntil(this.unsubscribe)).subscribe(data => {
      this.objects = data.objects;
    });
    this.buildTheForm();
  }

  private buildTheForm() {
    this.deleteForm = this.fb.group({
      objectsControl: this.fb.control([], Validators.required),
    });
  }

  private printObjectsNames(): void {
    this.deleteForm.controls.objectsControl.value.forEach(selectedId => {
      this._selectedObjects.push(this.objects.find(x => x.id === selectedId));
    });
  }

  public canILeave(): boolean {
    return this._canILeave;
  }

  public deleteObject(): void {
    this.markAsTouched(this.deleteForm);
    if (!this.deleteForm.valid) return;

    this.printObjectsNames();

    if (this._selectedObjects.length > 10) {
      this._warningDescription = 'Warning! ' + this._selectedObjects.length + ' objects are selected.';
      this._selectedObjects = [];
    } else {
      this._warningDescription = 'Warning! The following object(s) is selected';
    }

    this.confirmationPopUp
      .open({
        title: 'Are you sure you want to continue?',
        description:
          'By clicking Delete you confirm that all the selected Objects (and their associated information, e.g. constraints, columns, mappings) will be permanently deleted from the database.',
        warningDescription: this._warningDescription,
        selectedObjects: this._selectedObjects,
      })
      .subscribe(onClose => {
        if (onClose) {
          this.objectsService
            .deleteObject(this.deleteForm.controls.objectsControl.value)
            .pipe(take(1))
            .subscribe(_ => {
              this._canILeave = true;
              this.deleteForm.reset();
              this.toastr.success('Successfully deleted object(s)!');
              this.router.navigate(['/xml-data-maintenance/objects']);
            });
        } else {
          this._selectedObjects = [];
        }
      });
  }
}
