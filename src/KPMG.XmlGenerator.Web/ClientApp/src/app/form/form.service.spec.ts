import { TestBed } from '@angular/core/testing';

import { FormService } from './form.service';
import { HttpClientModule } from '@angular/common/http';

describe('FormService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientModule
    ]
  }));

  it('should be created', () => {
    const service: FormService = TestBed.get(FormService);
    expect(service).toBeTruthy();
  });
});
