import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../core/auth/auth.service';
import { map, catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): Observable<boolean> {

    let isAdmin: boolean;

    return this.authService.getUser().pipe(
      map(user => {
        isAdmin = user.isAdmin;
        if (!isAdmin) { this.router.navigate(['403']); }
        return isAdmin;
      }),
      catchError(err => {
        this.router.navigate(['401']);
        return of(false);
      })
    );
  }
}
