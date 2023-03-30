import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {CommonModule} from '@angular/common';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClient, HttpClientModule} from "@angular/common/http";
import {HomeModule} from "./home/home.module";
import {FlightsModule} from "./flights/flights.module";
import {ComponentsModule} from "./components/components.module";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AuthInterceptor} from "./interceptors/AuthInterceptor";
import {AuthenticationModule} from "./autentification/authentication.module";
import {ToastrModule} from 'ngx-toastr';
import {SearchModule} from "./search/search.module";


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HomeModule,
    FlightsModule,
    ComponentsModule,
    BrowserAnimationsModule,
    AuthenticationModule,
    CommonModule,
    SearchModule,
    ToastrModule.forRoot()
  ],
  providers: [HttpClient,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
