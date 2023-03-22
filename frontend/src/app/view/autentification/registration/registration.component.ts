import {Component} from '@angular/core';
import {AutentificationService} from "../../../services/autentificationService";
import {RegisterRequest} from "../../../model/autentification/register/RegisterRequest";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(private autentificationService: AutentificationService) {
  }

  register() {
    const newUser = new RegisterRequest();
    newUser.Email = "try2@gmail.com"
    newUser.FirstName = "try2"
    newUser.LastName = "try2"
    newUser.Password = "password"

    this.autentificationService.registerUser(newUser).subscribe({
      next: res => {
        console.log(res)
      }
    })
  }
}
