import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {RegistrationComponent} from "./view/autentification/registration/registration.component"
import {SignInComponent} from "./view/autentification/sign-in/sign-in.component";


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'flights', component: FlightsComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'signIn', component:SignInComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
