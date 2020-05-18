import { Component } from '@angular/core';
import { User } from './account/_models';
import { AuthenticationService } from './account/_services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {

  title = 'Rasky-Front';
  constructor(
    private authenticationService: AuthenticationService
) {
}

}
