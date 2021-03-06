import { FormService } from './form.service';
import { Component, OnInit, HostBinding, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Item } from './form.models';
import { NotificationService } from '@app/shared/services/notification.service';
import { TranslateService } from '@ngx-translate/core';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

// tslint:disable-next-line max-line-length
const EMAIL_PATTERN = '^.+@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit, OnDestroy {
  form: FormGroup;

  items: Item[];

  get headers() {
    if (this.items && this.items.length) {
      return Object.keys(this.items[0]);
    } else {
      return [];
    }
  }

  private unsubscribe = new Subject();

  constructor(private fb: FormBuilder,
              private formService: FormService,
              private notifyService: NotificationService,
              private translate: TranslateService) {}

  @HostBinding('class')
  public class = 'form';

  ngOnInit() {
    this.form = this.fb.group({
      product: ['', Validators.required],
      email: ['',  Validators.compose([Validators.required, Validators.pattern(EMAIL_PATTERN)])],
      price: ['', Validators.required],
      expiryDate: ['', Validators.required],
      discounted: [false]
    });

    this.formService.getData()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe((data) => {
      this.items = data;
    });
  }

  addItem() {
    if (this.form.valid) {
      const item = this.form.value as Item;
      // Normally you will be callling an API on the server here, but for the example we will just add new item to the array.
      this.items.push(item);
      this.notifyService.showSuccess(this.translate.instant('notifications.success.productAdded'));
    } else {
      // validate all form fields
      Object.keys(this.form.controls).forEach(field => {
        const control = this.form.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

}
