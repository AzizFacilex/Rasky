import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarpoolComponent } from './carpool/carpool-component';
import { NavigationComponent } from './navigation/navigation/navigation.component';
import { ProfileComponent } from './profile/profile.component';
import { CarpoolModule } from './carpool/carpool.module';
import { ProfileModule } from './profile/profile.module';

const routes: Routes = [
  {path:'',redirectTo:'home', pathMatch:'full'},
  {
    path: 'home', component: NavigationComponent, children: [
      {
        path:'showRide',
        loadChildren:()=>CarpoolModule,
        outlet:'carpool'
      },

      {
        path: 'create',
        loadChildren: () => CarpoolModule,
        outlet: 'carpool',
      },
      {
        path: 'public',
        loadChildren: () => ProfileModule,
        outlet: 'profile',
      },
      {
        path:'private',
        loadChildren:()=> ProfileModule,
        outlet:'profile'
      },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
