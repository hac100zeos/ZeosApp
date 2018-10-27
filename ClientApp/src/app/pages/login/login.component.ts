import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '../../services/account.service';
import { LoadingService } from '../../services/loading.service';

@Component({
	selector: 'zeos-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
	email: string;
	password: string;

	constructor(private _account: AccountService, private _loading: LoadingService, private _router: Router) {}

	login() {
		this._loading.setState(true);
		this._account
			.login({
				email: this.email,
				password: this.password,
			})
			.subscribe(
				() => {
					this._loading.setState(false);
					this._router.navigate(['/']);
				},
				(error) => {
					this._loading.setState(false);
					console.log(error);
				},
			);
	}
}
