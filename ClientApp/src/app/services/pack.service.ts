import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Pack } from '../models/api/pack';
import { PackInstance } from '../models/api/pack-instance';

@Injectable({
	providedIn: 'root',
})
export class PackService {
	constructor(private _http: HttpClient) {}

	getPackCategories(): Observable<Pack[]> {
		return this._http.get<Pack[]>('/assets/examples/pack-categories.json');
	}

	openPack(category: string): Observable<PackInstance> {
		return this._http.get<PackInstance>('/assets/examples/pack.json');
	}
}
