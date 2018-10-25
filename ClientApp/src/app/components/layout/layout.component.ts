import { Component, OnInit } from '@angular/core';

import { LoadingService } from '../../services/loading.service';

@Component({
	selector: 'zeos-layout',
	templateUrl: './layout.component.html',
	styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
	loading = false;

	constructor(private _loading: LoadingService) {}

	ngOnInit() {
		this._loading.loading.subscribe((loading) => (this.loading = loading));
	}
}
