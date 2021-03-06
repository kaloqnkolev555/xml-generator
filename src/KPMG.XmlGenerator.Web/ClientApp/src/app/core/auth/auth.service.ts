import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User, Claim } from './auth.models';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthConstants } from './auth.constants';

const ROLE_ADMIN = 'Admin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private CLAIM_ROLE = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
  private CLAIM_USERNAME = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name';
  private CLAIM_GROUP = 'ldap-memberOf';
  private URL_USER_TOKEN = '/api/SecurityUserToken';
  private LOCAL_STORAGE_TOKEN_KEY = 'access_token';
  private USER_NOT_AUTHORIZED: User = {
    authenticated: false,
    enabled: false,
    isAdmin: false,
    id: null,
    displayName: null,
    email: null,
    networkId: null,
    location: null,
    image: AuthConstants.DEFAULT_IMAGE,
    roles: null,
    groups: null,
    claims: null
  };

  constructor(private http: HttpClient) {
  }

  getUser(): Observable<User> {

    const localStorageToken = localStorage.getItem(this.LOCAL_STORAGE_TOKEN_KEY);
    if (!!localStorageToken) {
      // Local storage key found, check it
      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken(localStorageToken);
      const isExpired = helper.isTokenExpired(localStorageToken);

      if (!!decodedToken && !isExpired) {
        // Token is valid and not expired, return the user

        return of({
          authenticated: true,
          enabled: decodedToken['ldap-enabled'],
          isAdmin: this.isAdmin(decodedToken),
          id: this.getId(decodedToken),
          displayName: this.getDisplayName(decodedToken),
          email: decodedToken['ldap-email'],
          networkId: decodedToken['ldap-networkId'],
          location: decodedToken['ldap-location'],
          image: this.getImage(decodedToken),
          roles: decodedToken[this.CLAIM_ROLE] as string[],
          groups: this.getGroups(decodedToken),
          claims: this.getClaims(decodedToken)
        });
      }
    }

    // Not valid user in local storage, get it from api
    return this.getUserFromApi();
  }

  // Gets the user from API
  private getUserFromApi(): Observable<User> {
    return this.http.get(this.URL_USER_TOKEN)
      .pipe(map(response => {
        const token = response['token'];
        if (!!token) {
          const helper = new JwtHelperService();
          const decodedToken = helper.decodeToken(token);

          if (!!decodedToken) {
            localStorage.setItem(this.LOCAL_STORAGE_TOKEN_KEY, response['token']);
            return {
              authenticated: true,
              enabled: decodedToken['ldap-enabled'],
              isAdmin: this.isAdmin(decodedToken),
              id: this.getId(decodedToken),
              displayName: this.getDisplayName(decodedToken),
              email: decodedToken['ldap-email'],
              networkId: decodedToken['ldap-networkId'],
              location: decodedToken['ldap-location'],
              image: this.getImage(decodedToken),
              roles: decodedToken[this.CLAIM_ROLE] as string[],
              groups: this.getGroups(decodedToken),
              claims: this.getClaims(decodedToken)
            };
          }
        }

        return this.USER_NOT_AUTHORIZED;
      }));
  }

  private getClaims(token: object): Claim[] {
    const claims = new Array<Claim>();
    for (const key in token) {
      if (key.length !== 3 && !key.startsWith('ldap-')) {
        const value = token[key];
        if (value instanceof Array) {
          for (const claimValue of value) {
            claims.push({ key: key, value: claimValue });
          }
        } else {
          claims.push({ key: key, value: value });
        }
      }
    }
    return claims;
  }

  private getGroups(token: object): string[] {
    const groups = new Array<string>();
    for (const key in token) {
      if (key === this.CLAIM_GROUP) {
        if (token[key] instanceof Array) {
          for (const groupValue of token[key]) {
            groups.push(groupValue);
          }
        }
      }
    }
    return groups;
  }

  private getId(token: object): string {
    const username = token[this.CLAIM_USERNAME];
    if (username instanceof Array) {
      return token[this.CLAIM_USERNAME][0];
    } else {
      return token[this.CLAIM_USERNAME];
    }
  }

  private isAdmin(token: object): boolean {
    const roles = token[this.CLAIM_ROLE] as string[];
    if (!!roles) {
      return roles.indexOf(ROLE_ADMIN) >= 0;
    }
    return false;
  }

  private getDisplayName(token: object): string {
    const firstName = token['ldap-firstName'];
    const lastName = token['ldap-lastName'];
    if (!!firstName && !!lastName) {
      return firstName + ' ' + lastName;
    }
    return this.getId(token);
  }

  private getImage(token: object): string {
    const image = token['ldap-image'];
    if (!!image) {
      return 'data:image/jpg;base64,' + image;
    }
    return AuthConstants.DEFAULT_IMAGE;
  }
}
