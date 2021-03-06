import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { LayoutComponent } from './layout.component';

describe('LayoutComponent', () => {
	let component: LayoutComponent;
	let fixture: ComponentFixture<LayoutComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [LayoutComponent],
			imports: [HttpClientTestingModule, RouterTestingModule, FontAwesomeModule],
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(LayoutComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
