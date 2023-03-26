import {Component} from '@angular/core';
import {AutentificationService} from "../../../services/autentificationService";
import {RegisterRequest} from "../../model/register/RegisterRequest";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(private authenticationService: AutentificationService) {
  }

  register() {
    const newUser = new RegisterRequest();
    newUser.Email = "try2@gmail.com"
    newUser.FirstName = "try2"
    newUser.LastName = "try2"
    newUser.Password = "password"

    this.authenticationService.registerUser(newUser).subscribe({
      next: res => {
        console.log(res)
      }
    })
  }
}
