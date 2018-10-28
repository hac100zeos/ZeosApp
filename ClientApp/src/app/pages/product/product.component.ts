import { Component, OnInit } from '@angular/core';
import { faMoneyBill } from '@fortawesome/free-solid-svg-icons';

import { Product } from '../../models/api/product';

@Component({
	selector: 'zeos-product',
	templateUrl: './product.component.html',
	styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
	faMoneyBill = faMoneyBill;
	product: Product;

	constructor() {}

	ngOnInit() {
		this.product = <Product>{
			Id: '12345',
			Name: 'SAMSUNG QE85Q900 85" Smart 8K HDR QLED TV',
			Description:
				'8K in your living room\n' +
				'\n' +
				'The future of entertainment is here. The Samsung QE85Q900 85" Smart 8K HDR QLED TV brings impressively detailed 8K resolution to your living room, so you just see the picture, not the pixels. And that\'s not all – colours, textures, and skin tones are enriched – making every seat the best in the house.\n',
			Category: 'Television',
			ImageUrl: 'https://via.placeholder.com/300x200',
			Price: 14000,
		};
	}
}
