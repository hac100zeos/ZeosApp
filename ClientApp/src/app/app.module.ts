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
import { ProductComponent } from './pages/product/product.component';
import { AccountService } from './services/account.service';
import { LoadingService } from './services/loading.service';

@NgModule({
	declarations: [AppComponent, HomeComponent, LayoutComponent, LoginComponent, RegisterComponent, ProductComponent],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: 'login', component: LoginComponent },
			{ path: 'register', component: RegisterComponent },
			{ path: 'product', component: ProductComponent },
			{ path: '', component: HomeComponent, pathMatch: 'full' },
		]),
	],
	providers: [AccountService, LoadingService, { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
	bootstrap: [AppComponent],
})
export class AppModule {}
