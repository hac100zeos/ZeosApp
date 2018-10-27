import { AppPage } from './app.po';

describe('App', () => {
	let page: AppPage;

	beforeEach(() => {
		page = new AppPage();
	});

	it('should display element', () => {
		page.navigateTo();
		expect(page.getElement).toBeTruthy();
	});
});
