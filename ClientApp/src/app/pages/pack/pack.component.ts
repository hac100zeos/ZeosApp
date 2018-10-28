import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { mergeMap } from 'rxjs/operators';

import { PackService } from '../../services/pack.service';
import { PackInstance } from '../../models/api/pack-instance';

@Component({
	selector: 'zeos-pack',
	templateUrl: './pack.component.html',
	styleUrls: ['./pack.component.scss'],
})
export class PackComponent implements OnInit {
	pack: PackInstance;
	viewPack = false;
	animationIndex = 0;

	constructor(private _activatedRoute: ActivatedRoute, private _pack: PackService) {}

	ngOnInit() {
		this._activatedRoute.params
			.pipe(mergeMap((params) => this._pack.openPack(params.id)))
			.subscribe((pack) => (this.pack = pack));
		this.tickAnimation(6);
	}

	tickAnimation(maxAnimationIndex: number): void {
		this.animationIndex += 1;
		if (this.animationIndex < maxAnimationIndex) {
			setTimeout(() => this.tickAnimation(maxAnimationIndex), 500);
		}
	}
}
