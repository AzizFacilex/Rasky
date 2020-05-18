import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavigationModule} from './navigation/navigation.module';
import 'hammerjs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InterceptorService} from './interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AccountModule } from './account/account.module';
import { ProfileModule } from './profile/profile.module';
import { MatNativeDateModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
  
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    NavigationModule,
    AccountModule,
    ProfileModule,
    MatNativeDateModule

  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
