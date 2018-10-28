import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { mergeMap } from 'rxjs/operators';

import { Product } from '../../models/api/product';
import { ProductService } from '../../services/product.service';

@Component({
	selector: 'zeos-search',
	templateUrl: './search.component.html',
	styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
	searchQuery: string;
	results: Product[] = [];

	constructor(private _activatedRoute: ActivatedRoute, private _product: ProductService) {}

	ngOnInit() {
		this._activatedRoute.queryParams
			.pipe(
				mergeMap((queryParams) => {
					this.searchQuery = queryParams.query;
					return this._product.search(this.searchQuery);
				}),
			)
			.subscribe((results) => (this.results = results));
	}
}
