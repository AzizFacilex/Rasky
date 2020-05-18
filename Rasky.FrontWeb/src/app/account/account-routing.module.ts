import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home';
import { AuthGuard } from './_guards/auth.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  // {
  //     path: '',
  //     component: HomeComponent,
  //     canActivate: [AuthGuard]
  // },
  // {
  //     path: 'login',
  //     component: LoginComponent
  // },

  // // otherwise redirect to home
  // { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
