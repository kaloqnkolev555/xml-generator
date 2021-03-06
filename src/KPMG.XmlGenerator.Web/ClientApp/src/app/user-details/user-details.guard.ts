import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../core/auth/auth.service';
import { map, catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserDetailsGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): Observable<boolean> {

    let isAuthenticated: boolean;
    return this.authService.getUser().pipe(
      map(user => {
        isAuthenticated = user.authenticated;
        if (!isAuthenticated) { this.router.navigate(['401']); }
        return isAuthenticated;
      }),
      catchError(error => {
        this.router.navigate(['401']);
        return of(false);
      })
    );
  }
}
