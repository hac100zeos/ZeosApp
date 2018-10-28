import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
	selector: 'zeos-search',
	templateUrl: './search.component.html',
	styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
	searchQuery: string;

	constructor(private _activatedRoute: ActivatedRoute) {}

	ngOnInit() {
		this._activatedRoute.queryParams
			.pipe(
				mergeMap((queryParams) => {
					this.searchQuery = queryParams.query;
					return of({});
				}),
			)
			.subscribe(console.log);
	}
}
