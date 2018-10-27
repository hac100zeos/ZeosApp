import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'zeos-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
	searchQuery = '';

	constructor(private _http: HttpClient, private _router: Router) {}

	testAuth() {
		this._http.get('/api/Example/Index').subscribe(console.log, console.log);
	}

	search() {
		console.log(this.searchQuery);
		this._router.navigate(['search', { q: this.searchQuery }]);
	}
}
