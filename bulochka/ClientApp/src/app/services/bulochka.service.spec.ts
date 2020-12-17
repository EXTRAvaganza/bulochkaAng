import { TestBed } from '@angular/core/testing';

import { BulochkaService } from './bulochka.service';

describe('BulochkaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BulochkaService = TestBed.get(BulochkaService);
    expect(service).toBeTruthy();
  });
});
