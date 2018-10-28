import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { ProductService } from './product.service';

describe('ProductService', () => {
	beforeEach(() =>
		TestBed.configureTestingModule({
			imports: [HttpClientTestingModule],
		}));

	it('should be created', () => {
		const service: ProductService = TestBed.get(ProductService);
		expect(service).toBeTruthy();
	});
});
