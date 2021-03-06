import { Component, Input } from '@angular/core';
import { IBreadcrumb } from '@app/common/secondary-header';

@Component({
  selector: 'app-object-layout',
  templateUrl: './object-layout.component.html',
  styleUrls: ['./object-layout.component.scss'],
})
export class ObjectLayoutComponent {
  @Input() public mainTitle = '';

  @Input() public stepTitle = '';
  @Input() public breadcrumbs?: IBreadcrumb[];
}
