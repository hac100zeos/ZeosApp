import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/api/product';
import { Pack } from '../../models/api/pack';
import { PackService } from '../../services/pack.service';

@Component({
	selector: 'zeos-search-results',
	templateUrl: './search-results.component.html',
	styleUrls: ['./search-results.component.scss'],
})
export class SearchResultsComponent implements OnInit {
	products: Product[];

	constructor() {}

	ngOnInit() {}
}
