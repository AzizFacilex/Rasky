import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { JwtInterceptor} from './_helpers/jwt.interceptor'
import { HomeComponent } from './home/home.component';
import { ICON_REGISTRY_PROVIDER } from '@angular/material';
import { RegisterComponent } from './register/register.component';
import { MaterialModule } from '../shared/material/material.module';
import { AlertComponent } from '../shared/directives/alert/alert.component';
import { UniqueEmailDirective } from './_directives/unique-email.directive';
import { UserService, AuthenticationService } from './_services';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SharedModule } from '../shared/shared.module'; 
@NgModule({
  declarations: [
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    UniqueEmailDirective,
    ResetPasswordComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
    SharedModule

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    UserService,
    AuthenticationService
    // provider used to create fake backend
]
})
export class AccountModule { }
