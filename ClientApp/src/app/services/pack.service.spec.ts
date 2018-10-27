import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { PackService } from './pack.service';

describe('PackService', () => {
	beforeEach(() =>
		TestBed.configureTestingModule({
			imports: [HttpClientTestingModule],
		}));

	it('should be created', () => {
		const service: PackService = TestBed.get(PackService);
		expect(service).toBeTruthy();
	});
});
