import {
  Component,
  OnInit,
  Inject,
  AfterContentInit,
  Injectable
} from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControlName,
  AbstractControl,
  ValidatorFn,
  FormControl
} from '@angular/forms';
import { AuthenticationService, UserService } from '../_services';
import { first, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { User } from '../_models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { delay, debounceTime } from 'rxjs/operators';
import { FormsValidationService } from '../_services/forms-validation.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogData } from './DialogData';
import { AlertService } from 'src/app/shared/services/alert.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit, AfterContentInit {
  formGroup: FormGroup;
  firstNameFormGroup: FormGroup;
  lastNameFormGroup: FormGroup;
  emailFormGroup: FormGroup;
  passwordFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  registerForm: FormGroup;
  registerLoading = false;
  submitted = false;
  registrationResult = false;
  constructor(
    private _formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<RegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
  ngAfterContentInit() {}
  isPortrait(): boolean {
    return window.screen.width < window.screen.height;
  }

  ngOnInit() {
    this.formGroup = this.passwordFormGroup = this._formBuilder.group({
      passwordGroup: this._formBuilder.group(
        {
          password: ['', [Validators.required, Validators.minLength(8)]],
          confirmPassword: ['', [Validators.required, Validators.minLength(8)]]
        },

        {
          validator: FormsValidationService.MatchPassword
        }
      ),
      emailGroup: this._formBuilder.group(
        {
          // ValidateEmailNotTaken.createValidator(this.userService)
          email: ['', [Validators.required, Validators.email]],
          confirmEmail: ['', [Validators.required, Validators.email]]
        },
        {
          validator: FormsValidationService.MatchEmail
        }
      ),
      nameGroup: this._formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required]
      }),
      // phoneNumber: ['', [Validators.minLength(8), Validators.maxLength(8)]]
      phoneNumber: ''
    });
  }
  numberOnly(event): boolean {
    const charCode = event.which ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.formGroup.invalid) {
      console.log('invalid');
      return;
    }
    this.registerLoading = true;
    this.userService
      .register(this.formGroup.value)

      .pipe()
      .subscribe(
        (data: string) => {
          this.alertService.success('Registration successful', true);
          this.registerLoading = false;
          this.dialogRef.disableClose = true;

          setTimeout(() => {
            this.dialogRef.close();
          }, 2000);
        },
        error => {
          this.alertService.error(error);
          this.registerLoading = false;
        }
      );
  }
}
