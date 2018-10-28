import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { BasketComponent } from './basket.component';

describe('BasketComponent', () => {
	let component: BasketComponent;
	let fixture: ComponentFixture<BasketComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [BasketComponent],
			imports: [RouterTestingModule, FontAwesomeModule]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(BasketComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
