import { Injectable } from '@angular/core';
import {UserService} from './user.service';
import { FormControl, AbstractControl} from '@angular/forms'
import { map}from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class FormsValidationService {

  debouncer: any;
  constructor(){}
  // checkUsername(AC: AbstractControl): any {
  //   if(!AC.valueChanges)return;
  //   clearTimeout(this.debouncer);
  //   let a= new Promise(resolve => {

  //     this.debouncer = setTimeout(() => {
  //       this.userService.checkEmail(AC.value).subscribe((res) => {
  //         if(res.userName==="available"){

  //         }
  //       }, (err) => {
  //       console.log('im herer', JSON.stringify( AC.errors));
  //         return AC.setErrors({emailExists:true});
  //       });

  //     }, 2000);

  //   });
  //   console.log(JSON.stringify(a));
  //   return a;
  // }

  static MatchEmail(AC: AbstractControl) {
    let email = AC.get('email').value; // to get value in input tag
    let confirmEmail = AC.get('confirmEmail').value; // to get value in input tag
    if (email != confirmEmail) {
      AC.get('confirmEmail').setErrors({ MatchEmail: true })
    } else {
      return null
    }
  }
  static MatchPassword(AC: AbstractControl) {
    let password = AC.get('password').value; // to get value in input tag
    let confirmPassword = AC.get('confirmPassword').value; // to get value in input tag
    if (password != confirmPassword) {
      AC.get('confirmPassword').setErrors({ MatchPassword: true })
    } else {
      return null
    }
  }

}

export class ValidateEmailNotTaken {

  static createValidator(service: UserService) {
    return (control: AbstractControl) => {
      const value = control.value as string;
      return service.checkEmail(value).pipe(
        map((result: boolean) => result ? ({ taken: true }) : null)
      )
    }
  }
}
