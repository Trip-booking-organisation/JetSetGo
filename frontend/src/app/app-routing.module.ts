import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {RegistrationComponent} from "./view/autentification/registration/registration.component"
import {SignInComponent} from "./view/autentification/sign-in/sign-in.component";
import {HasRoleGuard} from "./guards/roleGuard/has-role.guard";
import {IsAuthentificatedGuard} from "./guards/authentificationGuard/is-authentificated.guard";
import { ErrorComponent } from './view/errors/errorPage/error.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'flights',
    component: FlightsComponent,
    canActivate:[HasRoleGuard,IsAuthentificatedGuard],
    data:{
      role: ["Admin","Passenger"]
    }
  },
  {
    path: 'registration',
    component: RegistrationComponent
  },
  {
    path: 'signIn',
    component:SignInComponent
  },
  {
    path:"error",
    component:ErrorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
