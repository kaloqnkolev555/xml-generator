import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { LoaderService, LoaderState } from './loader.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss'],
})
export class LoaderComponent implements OnInit, OnDestroy {
  show = false;
  private unsubscribe = new Subject();

  constructor(private loaderService: LoaderService) {}

  ngOnInit() {
    this.loaderService.loaderState.pipe(takeUntil(this.unsubscribe)).subscribe((state: LoaderState) => {
      this.show = state.show;
    });
  }

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}

