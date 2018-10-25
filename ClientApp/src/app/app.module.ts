import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LayoutComponent } from './components/layout/layout.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AccountService } from './services/account.service';
import { LoadingService } from './services/loading.service';

@NgModule({
	declarations: [AppComponent, HomeComponent, LoginComponent, RegisterComponent, LayoutComponent],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: 'login', component: LoginComponent },
			{ path: 'register', component: RegisterComponent },
			{ path: '', component: HomeComponent, pathMatch: 'full' },
		]),
	],
	providers: [AccountService, LoadingService],
	bootstrap: [AppComponent],
})
export class AppModule {}
