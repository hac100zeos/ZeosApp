import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Pack } from '../../models/api/pack';
import { LoadingService } from '../../services/loading.service';
import { PackService } from '../../services/pack.service';

@Component({
	selector: 'zeos-pack-browser',
	templateUrl: './pack-browser.component.html',
	styleUrls: ['./pack-browser.component.scss'],
})
export class PackBrowserComponent implements OnInit {
	packs: Pack[];

	constructor(private _router: Router, private _loading: LoadingService, private _packs: PackService) {}

	ngOnInit() {
		this._loading.setState(true);
		this._packs.getPackCategories().subscribe((packs) => {
			this.packs = packs;
			this._loading.setState(false);
		});
	}

	openPack(pack: Pack): void {
		this._packs.openPack(pack.Id).subscribe((packId) => this._router.navigate(['/pack/', packId]));
	}
}
