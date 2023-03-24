import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {SignInRequest} from "../../../model/autentification/signIn/SignInRequest";
import {AutentificationService} from "../../../services/autentificationService";
import {TokenStorageService} from "../../../services/tokenStorage.service";
import {RegisterRequest} from "../../../model/autentification/register/RegisterRequest";
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  email = "";
  password='';
  isLoggedIn = false
  container = document.querySelector(".container");

  signUpName='';
  signUpSurname='';
  signUpEmail='';
  signUpPassword='';
  signUpUsername='';

  @Output() onSignInOrRegister: EventEmitter<boolean> = new EventEmitter<boolean>();


  constructor(private autentificationService:AutentificationService,private tokenStorage: TokenStorageService,
              private router:Router) {}
  ngOnInit(): void {
    this.onSignInOrRegister.emit(true)
    this.container = document.querySelector(".container");
  }

  signIn() {
    var user = new SignInRequest({
      email: this.email,
      password:this.password}
    )
    this.autentificationService.signInUser(user).subscribe({

      next: res=>{
        this.logInUser(res)
      }
    })
  }

  logInUser(res:any){
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

    var registerRequest= new RegisterRequest()
    registerRequest.FirstName=this.signUpName;
    registerRequest.LastName=this.signUpSurname;
    registerRequest.Email=this.signUpEmail;
    registerRequest.Password = this.signUpPassword;
    this.autentificationService.registerUser(registerRequest).subscribe({
      next:res=>{
        console.log(res)
        this.logInUser(res)
        this.router.navigate(['']).then()
      }
    })
  }


}
