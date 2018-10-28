import { Component, OnInit } from '@angular/core';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';

import { ApplicationUser } from '../../models/api/application-user';
import { AccountService } from '../../services/account.service';
import { LoadingService } from '../../services/loading.service';
import { PurchaseService } from '../../services/purchase.service';

@Component({
	selector: 'zeos-layout',
	templateUrl: './layout.component.html',
	styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
	faSpinner = faSpinner;
	user: ApplicationUser;
	loading = false;
	basketCount: number;

	constructor(
		private _loading: LoadingService,
		private _account: AccountService,
		private _purchase: PurchaseService,
	) {}

	ngOnInit() {
		this._loading.loading.subscribe((loading) => (this.loading = loading));
		this._account.user.subscribe((user) => (this.user = user));
		this._purchase.basket.subscribe((products) => (this.basketCount = products.length));
	}
}
