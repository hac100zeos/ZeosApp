import { Component } from '@angular/core';

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

	constructor(private _account: AccountService, private _loading: LoadingService) {}

	login() {
		this._loading.setState(true);
		this._account
			.login({
				email: this.email,
				password: this.password,
			})
			.subscribe(
				(data) => {
					this._loading.setState(false);
					console.log(data);
				},
				(error) => {
					this._loading.setState(false);
					console.log(error);
				},
			);
	}
}
