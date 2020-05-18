import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from '../_services';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { DialogData } from '../register/DialogData';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  formGroup: FormGroup;
  sending=false;
  submitted=false;
  constructor(

    private formBuilder: FormBuilder,
    private userService: UserService,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<ResetPasswordComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit() {
    this.formGroup =  new FormGroup({
      email: new FormControl ('', [Validators.required, Validators.email]),

    });


  }
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.formGroup.invalid) {
      console.log('invalid');
      return;
    }
    this.sending = true;
    this.userService
      .resetPassword(this.formGroup.get('email').value)

      .pipe()
      .subscribe(
        (data) => {
          this.alertService.success('Rest link successfully sent', true);
          this.sending = false;
          this.dialogRef.disableClose = true;
        },
        error => {
          this.alertService.error(error);
          this.sending = false;
        }
      );
      }
    }
