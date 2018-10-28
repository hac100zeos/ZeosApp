import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Product } from '../models/api/product';

@Injectable({
	providedIn: 'root',
})
export class PurchaseService {
	readonly basket: BehaviorSubject<Product[]>;

	constructor() {
		const basket = localStorage.getItem('BASKET');
		if (basket) {
			this.basket = new BehaviorSubject<Product[]>(JSON.parse(basket));
		} else {
			this.basket = new BehaviorSubject<Product[]>([]);
		}
		this.basket.subscribe((b) => {
			localStorage.setItem('BASKET', JSON.stringify(b));
		});
	}

	addProductToBasket(product: Product): void {
		this.basket.next([...this.basket.value, product]);
	}

	clearBasket(): void {
		this.basket.next([]);
	}
}
