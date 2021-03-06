import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { ICgMetaObject } from '../../../../home/home.models';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MarkAllAsTouched, MARK_CONTROLS_AS_TOUCHED } from '../../../../common/forms';
import { IErrorSet } from '../../../../common/interfaces/error-set.interface';
import { CreateObjectSteps } from '../../objects-shared-module/resources';

@Component({
  selector: 'app-object-maintenance',
  templateUrl: './object-maintenance.component.html',
  styleUrls: ['./object-maintenance.component.scss'],
})
export class ObjectMaintenanceComponent implements OnInit {
  mainTitle = 'Object Maintenance';
  @ViewChild('modalSelectObjectForEdit', { static: false }) modalApplyAllSqlScriptsResults: ModalDirective;

  public cgMetaObjects: ICgMetaObject[] = [];
  public fgSelectObjectForEdit: FormGroup;
  public pageErrorSet: IErrorSet = {
    selectObjectForEdit: [{ type: 'required', message: 'Mandatory field' }],
  };

  constructor(
    private readonly route: ActivatedRoute,
    @Inject(MARK_CONTROLS_AS_TOUCHED)
    protected readonly markAsTouched: MarkAllAsTouched,
    private readonly router: Router,
  ) { }

  ngOnInit() {
    this.route.data.pipe(take(1)).subscribe(data => {
      this.cgMetaObjects = data.objects;
    });

    this.fgSelectObjectForEdit = new FormGroup({ selectObjectForEdit: new FormControl(null, [Validators.required]) });
  }

  public showEditModal() {
    this.fgSelectObjectForEdit.reset();
    this.modalApplyAllSqlScriptsResults.show();
  }

  public editObject() {
    this.markAsTouched(this.fgSelectObjectForEdit);
    if (!this.fgSelectObjectForEdit.valid) return;

    const id = this.fgSelectObjectForEdit.value.selectObjectForEdit.id;
    this.router.navigate([`/xml-data-maintenance/objects/edit/${id}/${CreateObjectSteps.OBJECT_OVERVIEW}`]);
  }
}
