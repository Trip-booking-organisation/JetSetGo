import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClient, HttpClientModule} from "@angular/common/http";
import {HomeModule} from "./home/home.module";
import {FlightsModule} from "./flights/flights.module";
import { RegistrationComponent } from './view/autentification/registration/registration.component';
import {ComponentsModule} from "./components/components.module";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { SignInComponent } from './view/autentification/sign-in/sign-in.component';
import {FormsModule} from "@angular/forms";
import {AuthInterceptor} from "./interceptors/AuthInterceptor";


@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HomeModule,
    FlightsModule,
    ComponentsModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [HttpClient,
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthInterceptor,
      multi:true
    }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
