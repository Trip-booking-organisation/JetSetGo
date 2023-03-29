import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {SignInRequest} from "../../model/signIn/SignInRequest";
import {AutentificationService} from "../../../services/autentificationService";
import {TokenStorageService} from "../../../services/tokenStorage.service";
import {RegisterRequest} from "../../model/register/RegisterRequest";
import {ActivatedRoute, Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import * as Aos from "aos";

const regex = /^[a-zA-Z0-9._%+-]+@gmail\.com$/;

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  email = "";
  password = '';
  isLoggedIn = false
  container = document.querySelector(".container");

  signUpName = '';
  signUpSurname = '';
  signUpEmail = '';
  signUpPassword = '';

  @Output() onSignInOrRegister: EventEmitter<boolean> = new EventEmitter<boolean>();


  constructor(private autentificationService: AutentificationService, private tokenStorage: TokenStorageService,
              private router: Router, private toast: ToastrService, private route: ActivatedRoute) {
    Aos.init({duration: 2000})
  }

  ngOnInit(): void {
    this.onSignInOrRegister.emit(true)
    this.container = document.querySelector(".container");
    this.route.queryParams.subscribe(params => {
      if (params['isRegistration']) {
        this.container?.classList.add("sign-up-mode");
      }
    })
  }

  checkSignInFields(): boolean {
    return !(this.email == "" || this.password == "");

  }

  signIn() {
    if (!this.checkSignInFields()) {
      this.toast.error("Please insert mail and password.", "Error")
    } else if (!this.checkEmailFormat(this.email)) {
      this.toast.error("Please insert mail correctly.", "Error")
    } else {
      this.doLoginCommand()
    }
  }

  checkEmailFormat(email: string): boolean {
    if (regex.test(email)) {
      return true;
    }
    return false;
  }

  doLoginCommand() {
    var user = new SignInRequest({
        email: this.email,
        password: this.password
      }
    )
    this.autentificationService.signInUser(user).subscribe({

      next: res => {
        this.logInUser(res)
      },
      error: err => {
        this.toast.error("Incorrect email or password.", "Error")
      }
    })
  }

  logInUser(res: any) {
    console.log(res)
    this.tokenStorage.saveToken(res.token!);
    this.tokenStorage.saveUser(res.token!);
    this.isLoggedIn = true;
    this.router.navigate(['']).then()
  }

  signUpMode() {
    this.container?.classList.add("sign-up-mode");
    console.log(this.container)
  }

  signInMode() {
    this.container?.classList.remove("sign-up-mode");
  }

  register() {
    if (!this.checkRegisterFields()) {
      this.toast.error("Please insert all sign up fields.", "Error")
    } else if (!this.checkEmailFormat(this.signUpEmail)) {
      this.toast.error("Please insert mail correctly.", "Error")
    } else {
      this.doRegisterCommand();
    }
  }

  doRegisterCommand() {
    var registerRequest = new RegisterRequest()
    registerRequest.FirstName = this.signUpName;
    registerRequest.LastName = this.signUpSurname;
    registerRequest.Email = this.signUpEmail;
    registerRequest.Password = this.signUpPassword;
    this.autentificationService.registerUser(registerRequest).subscribe({
      next: res => {
        console.log(res)
        this.logInUser(res)
        this.router.navigate(['']).then()
      },
      error: err => {
        this.toast.error(err, "Error")
      }
    })
  }

  checkRegisterFields(): boolean {
    return !(this.signUpEmail == "" || this.signUpPassword == "" || this.signUpSurname == "" || this.signUpName == "");
  }


}
