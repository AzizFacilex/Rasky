import { MaterialModule } from './../shared/material/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarpoolRoutingModule } from './carpool-routing.module';
import { RideInfoListComponent } from './ride-info-list/ride-info-list.component';
import { CarpoolComponent} from '../carpool/carpool-component';
import { CreateRideComponent } from './create-ride/create-ride.component';
import { CarpoolService } from './services/carpool.service';
import { from } from 'rxjs';
import { MapService } from './services/map.service';
import { RideInfoComponent } from './ride-info/ride-info.component';

@NgModule({
  declarations: [ RideInfoListComponent, CarpoolComponent, CreateRideComponent, RideInfoComponent],
  imports: [
    CommonModule,
    CarpoolRoutingModule,
    MaterialModule,
  ],
  exports:[ RideInfoListComponent, CarpoolComponent],
  providers:[CarpoolService,MapService]
})
export class CarpoolModule { }
