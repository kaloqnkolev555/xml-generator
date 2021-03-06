import { Component, OnInit, OnDestroy } from '@angular/core';
import { User } from '../core/auth/auth.models';
import { AuthService } from '../core/auth/auth.service';
import { SafeResourceUrl } from '@angular/platform-browser';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})

export class UserDetailsComponent implements OnInit, OnDestroy {
  user: User;
  imagePath: SafeResourceUrl;
  private unsubscribe = new Subject();

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.getUser()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(res => this.user = res);
  }

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

}
