import { Component, ViewContainerRef, OnInit } from '@angular/core';
import { ViewContainerRefService } from './shared/services/view-container-ref.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(
    private readonly viewContainerRef: ViewContainerRef,
    private readonly viewContainerRefService: ViewContainerRefService
  ) {}

  ngOnInit() {
    this.viewContainerRefService.viewContainerRef = this.viewContainerRef;
  }
}
