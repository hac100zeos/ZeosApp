import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { LayoutComponent } from './components/layout/layout.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { BasketComponent } from './pages/basket/basket.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { PackComponent } from './pages/pack/pack.component';
import { PackBrowserComponent } from './pages/pack-browser/pack-browser.component';
import { ProductComponent } from './pages/product/product.component';
import { RegisterComponent } from './pages/register/register.component';
import { SearchComponent } from './pages/search/search.component';
import { AccountService } from './services/account.service';
import { LoadingService } from './services/loading.service';
import { ProductService } from './services/product.service';
import { PurchaseService } from './services/purchase.service';

@NgModule({
	declarations: [
		AppComponent,
		BasketComponent,
		CheckoutComponent,
		HomeComponent,
		LayoutComponent,
		LoginComponent,
		ProductComponent,
		PackComponent,
		PackBrowserComponent,
		RegisterComponent,
		SearchComponent,
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: 'basket', component: BasketComponent },
			{ path: 'checkout', component: CheckoutComponent },
			{ path: 'login', component: LoginComponent },
			{ path: 'register', component: RegisterComponent },
			{ path: 'packs', component: PackBrowserComponent },
			{ path: 'pack/:id', component: PackComponent },
			{ path: 'product/:id', component: ProductComponent },
			{ path: 'search', component: SearchComponent },
			{ path: '', component: HomeComponent, pathMatch: 'full' },
		]),
		FontAwesomeModule,
	],
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
		AccountService,
		LoadingService,
		ProductService,
		PurchaseService,
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
