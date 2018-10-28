import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Product } from '../models/api/product';

@Injectable({
	providedIn: 'root',
})
export class ProductService {
	constructor(private _http: HttpClient) {}

	getProduct(id: string): Observable<Product> {
		return this._http.get<Product>('/assets/examples/product.json');
	}
}
