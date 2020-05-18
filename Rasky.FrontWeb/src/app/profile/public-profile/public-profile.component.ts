import { Component, OnInit } from '@angular/core';
import { Profile } from '../models/Profile';
import { ProfileService } from '../services/profile.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-public-profile',
  templateUrl: './public-profile.component.html',
  styleUrls: ['./public-profile.component.scss']
})
export class PublicProfileComponent implements OnInit {
  profile = new Profile();
  id:string;
  constructor(private profileService: ProfileService, private route :  ActivatedRoute) { }
  isLoading: boolean = true;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id']; // (+) converts string 'id' to a number
console.log(JSON.stringify(params));
      // In a real app: dispatch action to load the details here.
   });
    this.profileService.getPublicProfile(this.id).subscribe(
      (res: Profile) => {
        this.profile = res;
      }
    )
  }

}
