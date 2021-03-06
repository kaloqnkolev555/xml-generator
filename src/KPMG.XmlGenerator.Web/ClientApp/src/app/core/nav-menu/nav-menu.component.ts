import { Component, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs';

export const DEFAULT_LANG = 'en';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent implements OnDestroy {
  private unsubscribe = new Subject();

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
