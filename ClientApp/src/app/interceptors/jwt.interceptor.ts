import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		// Add authorization header with JWT Token if available
		const jwt = JSON.parse(localStorage.getItem('CURRENT_USER'));
		if (jwt && jwt.token) {
			request = request.clone({
				setHeaders: {
					Authorization: `Bearer ${jwt.token}`,
				},
			});
		}
		return next.handle(request);
	}
}
