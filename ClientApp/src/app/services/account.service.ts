import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ApplicationUser } from '../models/api/application-user';
import { UserLogin } from '../models/api/user-login';
import { Jwt } from '../models/jwt';
import { JwtPayload } from '../models/jwt-payload';

@Injectable({
	providedIn: 'root',
})
export class AccountService {
	user: BehaviorSubject<ApplicationUser>;

	constructor(private _http: HttpClient) {
		const token = localStorage.getItem('CURRENT_USER');
		if (token) {
			const jwt = <Jwt>JSON.parse(token);
			this.user = new BehaviorSubject<ApplicationUser>(<ApplicationUser>{
				email: jwt.payload.sub,
			});
		} else {
			this.user = new BehaviorSubject<ApplicationUser>(null);
		}
	}

	login(user: UserLogin): Observable<Jwt> {
		return this._http.post('/api/Account/Login', user, { responseType: 'text' }).pipe(
			map((token) => {
				const tokenParts = token.split('.');
				const jwt = <Jwt>{
					payload: <JwtPayload>JSON.parse(atob(tokenParts[1])),
					token,
				};
				if (jwt) {
					localStorage.setItem('CURRENT_USER', JSON.stringify(jwt));
				}
				this.user.next(<ApplicationUser>{
					email: jwt.payload.sub,
				});
				return jwt;
			}),
		);
	}

	logout(): void {
		localStorage.removeItem('CURRENT_USER');
		this.user.next(null);
	}
}
