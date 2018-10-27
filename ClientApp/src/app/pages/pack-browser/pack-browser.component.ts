import { Component, OnInit } from '@angular/core';

import { Pack } from '../../models/api/pack';
import { PackService } from '../../services/pack.service';

@Component({
	selector: 'zeos-pack-browser',
	templateUrl: './pack-browser.component.html',
	styleUrls: ['./pack-browser.component.scss'],
})
export class PackBrowserComponent implements OnInit {
	packs: Pack[];

	constructor(private _packs: PackService) {}

	ngOnInit() {
		this._packs.getPackCategories().subscribe((packs) => (this.packs = packs));
	}
}
