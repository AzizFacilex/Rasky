import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './../shared/material/material.module';
import { ProfileRoutingModule } from './profile-routing.module';
import { PublicProfileComponent } from './public-profile/public-profile.component';
import { PrivateProfileComponent } from './private-profile/private-profile.component';
import { ProfileComponent } from './profile.component';
import { ProfileService } from './services/profile.service';

@NgModule({
  declarations: [PublicProfileComponent, PrivateProfileComponent, ProfileComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ProfileRoutingModule
    
  ],
  exports:[ProfileComponent],
  providers:[ProfileService]
})
export class ProfileModule { }
