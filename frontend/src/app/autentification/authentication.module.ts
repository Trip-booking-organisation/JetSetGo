import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SignInComponent} from "./view/sign-in/sign-in.component";
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [SignInComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [SignInComponent]
})
export class AuthenticationModule {
}
