import { TestBed } from '@angular/core/testing';

import { PurchaseService } from './purchase.service';

describe('PurchaseService', () => {
	beforeEach(() => TestBed.configureTestingModule({}));

	it('should be created', () => {
		const service: PurchaseService = TestBed.get(PurchaseService);
		expect(service).toBeTruthy();
	});
});
