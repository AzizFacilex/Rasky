import { Directive } from '@angular/core';
import { AsyncValidator, AbstractControl, ValidationErrors, NG_ASYNC_VALIDATORS } from '@angular/forms';
import { promise } from 'protractor';
import { Observable } from 'rxjs';
import { UserService } from '../_services';
import { map } from 'rxjs/operators';

@Directive({
  selector: '[uniqueEmail]',
  providers:[{
    provide:NG_ASYNC_VALIDATORS,useExisting:UniqueEmailDirective,multi:true
  }]
})
export class UniqueEmailDirective implements AsyncValidator {

  constructor(private userService:UserService) { }
  
  validate(c:AbstractControl):Promise<ValidationErrors | null>| Observable<ValidationErrors|null>
  {
    return this.userService.checkEmail(c.value).pipe(map(
      res=>
      {
        return res ? {'taken':true}:null;
      }
    ))
  }

}
