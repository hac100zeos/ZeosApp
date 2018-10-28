import { Component, OnInit } from '@angular/core';

import { Product } from '../../models/api/product';
import { PurchaseService } from '../../services/purchase.service';

@Component({
	selector: 'zeos-basket',
	templateUrl: './basket.component.html',
	styleUrls: ['./basket.component.scss'],
})
export class BasketComponent implements OnInit {
	basket: Product[];

	constructor(private _purchase: PurchaseService) {}

	ngOnInit() {
		this._purchase.basket.subscribe((basket) => (this.basket = basket));
	}
}
