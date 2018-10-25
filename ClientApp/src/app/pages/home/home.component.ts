import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
	selector: 'zeos-home',
	templateUrl: './home.component.html',
})
export class HomeComponent {
	constructor(private http: HttpClient) {}

	testAuth() {
		this.http
			.get('/api/Example/Index')
			.subscribe(console.log, console.log);
	}
}
