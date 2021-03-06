import { InjectionToken } from '@angular/core';
import { IEnvironment } from 'environments/environment.interface';

export const APP_CONFIG = new InjectionToken<IEnvironment>('app.config');
