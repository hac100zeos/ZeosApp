import { Component, OnInit } from '@angular/core';

import { Product } from '../../models/api/product';
import { PurchaseService } from '../../services/purchase.service';
import { faMoneyBill } from '@fortawesome/free-solid-svg-icons';
@Component({
	selector: 'zeos-basket',
	templateUrl: './basket.component.html',
	styleUrls: ['./basket.component.scss'],
})
export class BasketComponent implements OnInit {
	products: Product[];
	faMoneyBill = faMoneyBill;
	totalPrice: number;

	constructor(private _purchase: PurchaseService) {}

	ngOnInit() {
		this._purchase.basket.subscribe((products) => {
			this.products = products;
			this.totalPrice = products.reduce((p1, p2) => p1 + p2.price, 0);
		});
	}
}
