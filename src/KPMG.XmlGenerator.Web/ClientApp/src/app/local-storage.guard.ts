import { Injectable } from '@angular/core';
import { CanActivate, Router, CanActivateChild } from '@angular/router';
import { LocalStorageService } from './shared/services/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageGuard implements CanActivate, CanActivateChild {
  constructor(
    private router: Router,
    private localStorageService: LocalStorageService
    ) { }

  canActivate(): boolean {
    const db = this.localStorageService.getDb();
    const version = this.localStorageService.getVersion();

    if (!!db && !!db.id && !!version && !!version.id) {
      return true;
    }

    this.router.navigate(['']);
    return false;
  }

  canActivateChild(): boolean {
    return this.canActivate();
  }
}
