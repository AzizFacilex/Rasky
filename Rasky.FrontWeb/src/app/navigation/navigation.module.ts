import { CarpoolModule } from './../carpool/carpool.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationRoutingModule } from './navigation-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { NavigationComponent } from './navigation/navigation.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { RegisterComponent } from '../account/register/register.component';
import { LoginComponent } from '../account/login/login.component';
import { AccountModule } from '../account/account.module';
import { ResetPasswordComponent } from '../account/reset-password/reset-password.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ NavigationComponent ],
  entryComponents:[RegisterComponent,ResetPasswordComponent],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    MaterialModule,
    CarpoolModule,
    SharedModule
  ],
  exports:
  [
    NavigationComponent
   ]
})
export class NavigationModule { }
