import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { PackComponent } from './pack.component';

describe('PackComponent', () => {
	let component: PackComponent;
	let fixture: ComponentFixture<PackComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [PackComponent],
			imports: [HttpClientTestingModule, RouterTestingModule],
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(PackComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
