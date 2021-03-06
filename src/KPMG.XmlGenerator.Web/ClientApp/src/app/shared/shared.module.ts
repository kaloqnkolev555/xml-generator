import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { ErrorComponent } from './components/error/error.component';
import { InputMaskDirective } from './directives/input-mask/input-mask.directive';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchSelectModule } from '@app/common/search-select/search-select.module';
import { DisableControlDirective } from './directives/disable-form-control/disable-form-control.directive';
import { ConfirmationPopupModule } from '@app/common/confirmation-popup/confirmation-popup.module';
import { XmlButtonModule } from '@app/xml-data-maintenance/xml-button/xml-button.module';
import { StickyFooterModule } from '@app/common/sticky-footer/sticky-footer.module';
import { KpmgFormFieldModule } from '@app/common/kpmg-form-field/kpmg-form-field.module';
import { markAllAsTouched, MARK_CONTROLS_AS_TOUCHED } from '@app/common/forms/mark-all-as-touched.forms';
import { NgSelectWrapperModule } from '@app/common/ng-select-wrapper/ng-select-wrapper.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { ToggleButtonModule } from '@app/common/toggle-button/toggle-button.module';
import { ErrorJsonComponent } from './components/error-json/error-json.component';
import { TooltipModule } from 'ngx-bootstrap';
import { COMPARE_CONSTRAINTS, compareConstraints } from '@app/common/form-validators/compare-constraints.validator';
import { COMPARE_H_CONSTRAINTS, compareHConstraints } from '@app/common/form-validators/compare-hconstraints.validator'
import { AccordionModule } from '@app/common/accordion/accordion.module';

const NOTIFICATION_TIMEOUT = 20000;

const sharedImports = [
  CommonModule,
  TranslateModule,
  FormsModule,
  ReactiveFormsModule,
  SearchSelectModule,
  ConfirmationPopupModule,
  XmlButtonModule,
  StickyFooterModule,
  KpmgFormFieldModule,
  NgSelectWrapperModule,
  NgSelectModule,
  ToggleButtonModule,
  AccordionModule,
];

const sharedDeclarations = [ErrorComponent, ErrorJsonComponent, InputMaskDirective, DisableControlDirective];

@NgModule({
  declarations: [...sharedDeclarations],
  imports: [
    ...sharedImports,
    ToastrModule.forRoot({ timeOut: NOTIFICATION_TIMEOUT }),

    // ngx-bootstrap
    TooltipModule.forRoot(),
  ],

  providers: [
    { provide: MARK_CONTROLS_AS_TOUCHED, useValue: markAllAsTouched },
    { provide: COMPARE_CONSTRAINTS, useValue: compareConstraints },
    { provide: COMPARE_H_CONSTRAINTS, useValue: compareHConstraints },
  ],

  exports: [...sharedImports, ...sharedDeclarations, ToastrModule, TooltipModule],
})
export class SharedModule {}
