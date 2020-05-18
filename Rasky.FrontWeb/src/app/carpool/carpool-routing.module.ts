import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RideInfoListComponent } from './ride-info-list/ride-info-list.component';
import { CarpoolComponent } from './carpool-component';
import { CreateRideComponent } from './create-ride/create-ride.component';
import { RideInfoComponent } from './ride-info/ride-info.component';

const routes: Routes = [
  { path: '', redirectTo: 'create', pathMatch: 'full' },
  { path: 'create', component: CreateRideComponent },
  { path: ':id', component: RideInfoComponent }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarpoolRoutingModule { }
