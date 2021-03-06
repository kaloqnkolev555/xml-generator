export interface Claim {
  key: string;
  value: string;
}

export interface User {
  authenticated: boolean;
  enabled: boolean;
  isAdmin: boolean;
  id: string;
  displayName: string;
  email: string;
  networkId: string;
  location: string;
  image: string;
  roles: string[];
  groups: string[];
  claims: Claim[];
}
