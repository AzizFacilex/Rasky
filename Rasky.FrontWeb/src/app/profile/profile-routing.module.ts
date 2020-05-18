import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile.component';
import { PublicProfileComponent } from './public-profile/public-profile.component';
import { PrivateProfileComponent } from './private-profile/private-profile.component';

const routes: Routes = [
  { path: '', component:PrivateProfileComponent },
  { path: ':id', component: PublicProfileComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule {}
