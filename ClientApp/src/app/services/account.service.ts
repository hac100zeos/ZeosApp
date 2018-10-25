import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { UserLogin } from '../models/api/user-login';

@Injectable({
	providedIn: 'root',
})
export class AccountService {
	constructor(private _http: HttpClient) {}

	login(user: UserLogin): Observable<string> {
		return this._http.post<string>('/api/Account/Login', user);
	}
}
