import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LayoutComponent } from './components/layout/layout.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { PackComponent } from './pages/pack/pack.component';
import { PackBrowserComponent } from './pages/pack-browser/pack-browser.component';
import { ProductComponent } from './pages/product/product.component';
import { AccountService } from './services/account.service';
import { LoadingService } from './services/loading.service';

@NgModule({
	declarations: [
		AppComponent,
		HomeComponent,
		LayoutComponent,
		LoginComponent,
		RegisterComponent,
		ProductComponent,
		PackComponent,
		PackBrowserComponent,
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: 'login', component: LoginComponent },
			{ path: 'register', component: RegisterComponent },
			{ path: 'packs', component: PackBrowserComponent },
			{ path: 'pack/:id', component: PackComponent },
			{ path: 'product', component: ProductComponent },
			{ path: '', component: HomeComponent, pathMatch: 'full' },
		]),
	],
	providers: [AccountService, LoadingService, { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
	bootstrap: [AppComponent],
})
export class AppModule {}
