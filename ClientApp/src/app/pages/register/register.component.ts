import { Component } from '@angular/core';

@Component({
	selector: 'zeos-register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
	email: string;
	emailConfirm: string;
	password: string;

	constructor() {}

	register() {}
}
