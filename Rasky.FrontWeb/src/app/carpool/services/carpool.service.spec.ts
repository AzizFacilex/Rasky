import { TestBed } from '@angular/core/testing';

import { CarpoolService } from './carpool.service';

describe('CarpoolService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CarpoolService = TestBed.get(CarpoolService);
    expect(service).toBeTruthy();
  });
});
