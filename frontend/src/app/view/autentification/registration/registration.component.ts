import { Component } from '@angular/core';
import {AutentificationService} from "../../../services/autentificationService";
import {RegisterRequest} from "../../../model/autentification/RegisterRequest";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(private autentificationService: AutentificationService) {
  }
  register() {
    var newUser = new RegisterRequest()
    newUser.Email = "try@gmail.com"
    newUser.FirstName = "try"
    newUser.LastName = "try"
    newUser.Password = "password"

    this.autentificationService.registerUser(newUser).subscribe({
      next:res =>{
        console.log(res)
      }
    })
  }
}
