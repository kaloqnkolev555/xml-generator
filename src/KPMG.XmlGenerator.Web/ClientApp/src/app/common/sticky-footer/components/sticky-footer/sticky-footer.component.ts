import {
  Component,
  HostListener,
  Inject,
  AfterViewInit,
  Input,
  Renderer2,
  ViewChild,
  ElementRef,
  OnDestroy,
} from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-sticky-footer',
  templateUrl: './sticky-footer.component.html',
  styleUrls: ['./sticky-footer.component.scss'],
})
export class StickyFooterComponent implements AfterViewInit, OnDestroy {
  private unsubscribe = new Subject();

  @Input() optionalText = '';
  public stickToBottom = false;

  @ViewChild('footer', { static: true })
  public readonly footer: ElementRef;

  constructor(
    @Inject(DOCUMENT)
    private readonly document: Document,
    private readonly renderer2: Renderer2,
    private readonly router: Router
  ) {}

  ngAfterViewInit() {
    this.checkHeight();
    this.router.events.pipe(takeUntil(this.unsubscribe)).subscribe(val => {
      // see also
      if (val instanceof NavigationEnd) {
        this.checkHeight();
      }
    });
  }

  public checkHeight() {
    if (
      this.stickToBottom &&
      this.document.documentElement.scrollTop >= this.document.body.scrollHeight - this.document.body.clientHeight - 40
    ) {
      this.hide();
    } else if (
      this.document.documentElement.scrollTop <=
      this.document.body.scrollHeight - this.document.body.clientHeight - 40
    ) {
      this.show();
    } else {
      this.hide();
    }
  }

  private show() {
    this.renderer2.addClass(this.footer.nativeElement, 'sticky-bottom');
  }

  private hide() {
    this.renderer2.removeClass(this.footer.nativeElement, 'sticky-bottom');
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.checkHeight();
  }

  @HostListener('window:resize', [])
  onWindowResize() {
    this.checkHeight();
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
