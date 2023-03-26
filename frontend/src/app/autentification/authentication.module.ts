import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SignInComponent} from "./view/sign-in/sign-in.component";
import {RegistrationComponent} from "./view/registration/registration.component";
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [SignInComponent, RegistrationComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [SignInComponent, RegistrationComponent]
})
export class AuthenticationModule {
}
