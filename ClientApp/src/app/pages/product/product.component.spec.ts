import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { ProductComponent } from './product.component';

describe('ProductComponent', () => {
	let component: ProductComponent;
	let fixture: ComponentFixture<ProductComponent>;

	beforeEach(async(() => {
		TestBed.configureTestingModule({
			declarations: [ProductComponent],
			imports: [RouterTestingModule, FontAwesomeModule],
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(ProductComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
