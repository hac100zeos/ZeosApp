import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

@Component({
	selector: 'zeos-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
	faSearch = faSearch;
	searchQuery = '';

	constructor(private _router: Router) {}

	search(): void {
		this._router.navigate(['/search'], { queryParams: { query: this.searchQuery } });
	}
}
