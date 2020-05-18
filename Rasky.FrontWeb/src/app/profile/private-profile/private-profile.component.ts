import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../services/profile.service';
import { Profile } from '../models/Profile';
import { ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UpdateName } from '../models/UpdateName'

@Component({
  selector: 'app-private-profile',
  templateUrl: './private-profile.component.html',
  styleUrls: ['./private-profile.component.scss']
})

export class PrivateProfileComponent implements OnInit {
  privateProfile = new Profile();
  clickInside: boolean = false;
  profileStringifier = JSON.stringify;
  @ViewChild("nameForm") nameForm: NgForm;

  updateNameM: UpdateName;

  constructor(private profileService: ProfileService) { }

  ngOnInit() {
    this.updateNameM = {
      firstName:'',
      lastName:'',
    }
  }

  @ViewChild("insideElement") insideElement;
  @HostListener('document:click', ['$event.target'])
  public onClickInput(targetElement) {
    const clickedInside = this.insideElement.nativeElement.contains(targetElement);
    if (clickedInside) {
      this.clickInside = true;
    } else this.clickInside = false;

    console.log(this.clickInside);
  }
  updateName() {
    console.log(this.nameForm);
    var fName = this.nameForm.form.controls['firstName'].value;
    var lName = this.nameForm.form.controls['lastName'].value;
    this.profileService.updateName(fName, lName).subscribe((res: Profile) => {
      this.privateProfile = res;
    })
  }

}