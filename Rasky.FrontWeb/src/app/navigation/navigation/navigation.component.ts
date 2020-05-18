import { Component, OnInit, Input } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { RegisterComponent } from 'src/app/account/register/register.component';
import { LoginComponent } from 'src/app/account/login/login.component';
import { AuthenticationService } from 'src/app/account/_services';
import { Router, ActivatedRoute } from '@angular/router';
import {
  trigger,
  state,
  style,
  transition,
  animate
} from '@angular/animations';
import {
  Validators,
  FormControl,
  FormGroup,
  FormBuilder
} from '@angular/forms';
import { first } from 'rxjs/operators';
import { User } from 'src/app/account/_models';
import { Subscription, Observable } from 'rxjs';
import { ResetPasswordComponent } from 'src/app/account/reset-password/reset-password.component';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  animations: [
    trigger('sideBarState', [
      state(
        'expanded',
        style({
          width: '150px'
        })
      ),
      state(
        'collapsed',
        style({
          width: '70px'
        })
      ),
      transition('collapsed=>expanded', animate('150ms')),
      transition('expanded=>collapsed', animate('150ms'))
    ]),
    trigger('flyInOut', [
      transition('void=>*', [
        style({ transform: 'translateX(-100vw)' }),
        animate('0.75s', style({ transform: 'translateY(0vw)' }))
      ]),
      transition('*=>void', [
        animate('0.75s', style({ transform: 'translateX(100vw)' }))
      ])
    ])
  ]
})
export class NavigationComponent implements OnInit {
  focus = 'carpool';
  t='profile';
  loginForm: FormGroup;
  loginLoading = false;
  submitted = false;
  loading = false;
  returnUrl: string;
  error = '';
  @Input() currentSideBarState;
  SideBar = 'collapsed';
  fillerNav = Array.from({ length: 50 }, (_, i) => `Nav Item ${i + 1}`);
  fillerContent = Array.from(
    { length: 50 },
    () =>
      `Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
   labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco
   laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in
   voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
   cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.`
  );
  registerDialogRef: MatDialogRef<RegisterComponent>;
  resetPasswordDialogRef: MatDialogRef<ResetPasswordComponent>;
  currentUser: User;
  activeRouter:string;
  currentUserSubscription: Subscription;
  constructor(
    public dialog: MatDialog,
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private alertService: AlertService,
    private router: Router
  ) {
    this.currentUserSubscription = this.authenticationService.currentUser.subscribe(
      user => {
        this.currentUser = user;
      }
    );
  }
  setFocus(e) {
    this.focus = e;
    switch(this.focus)
    {
      case 'carpool':{
        this.otherRouters='profile';
      }
      case 'profile':{
        this.otherRouters='carpool';
      }
    }

    console.log(this.focus);
  }
  openDialogForgotPassword() {
    this.resetPasswordDialogRef = this.dialog.open(ResetPasswordComponent, {
      data: {}
    });
  }
  openDialogRegister() {
    this.registerDialogRef = this.dialog.open(RegisterComponent, {
      data: {}
    });
  }
  toggleSideBar() {
    this.SideBar = this.SideBar === 'collapsed' ? 'expanded' : 'collapsed';
  }
  toggleActive(e: any) {}
  otherRouters='';
  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      emailFormControl: ['', [Validators.required, Validators.email]],
      passwordFormControl: ['', Validators.required]
    });
  }
  get f() {
    return this.loginForm.controls;
  }
  logout() {
    this.SideBar = 'collapsed';
    this.authenticationService.logout();
  }
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loginLoading = true;
    setTimeout(() => {
      this.authenticationService
        .login(this.f.emailFormControl.value, this.f.passwordFormControl.value)
        .pipe(first())
        .subscribe(
          data => {
            this.loginForm.reset();
            this.loginLoading = false;
            this.SideBar = 'collapsed';
          },
          error => {
            this.loginForm.reset();
            this.alertService.error(error);
            this.error = error;
            this.loginLoading = false;
          }
        );
    }, 2000);
  }
}
