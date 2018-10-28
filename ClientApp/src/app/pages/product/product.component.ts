import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { faMoneyBill } from '@fortawesome/free-solid-svg-icons';
import { mergeMap } from 'rxjs/operators';

import { Product } from '../../models/api/product';
import { LoadingService } from '../../services/loading.service';
import { ProductService } from '../../services/product.service';
import { PurchaseService } from '../../services/purchase.service';

@Component({
	selector: 'zeos-product',
	templateUrl: './product.component.html',
	styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
	faMoneyBill = faMoneyBill;
	product: Product;

	constructor(
		private _activatedRoute: ActivatedRoute,
		private _loading: LoadingService,
		private _product: ProductService,
		private _purchase: PurchaseService,
	) {}

	ngOnInit() {
		this._loading.setState(true);
		this._activatedRoute.params
			.pipe(mergeMap((params) => this._product.getProduct(params.id)))
			.subscribe((product) => {
				this.product = product;
				this._loading.setState(false);
			});
	}

	addToBasket(): void {
		this._purchase.addProductToBasket(this.product);
	}
}
