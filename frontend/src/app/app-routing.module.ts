import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {SignInComponent} from "./autentification/view/sign-in/sign-in.component";
import {ErrorComponent} from './components/errors/errorPage/error.component';
import {FlightSeatsComponent} from "./flights/ui/flight-seats/flight-seats.component";
import {UsersTicketsComponent} from './components/users-tickets/users-tickets.component';
import {CreateFlightComponent} from "./create-flight/ui/create-flight.component";


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'flights',
    component: FlightsComponent,
    // canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    // data: {
    //   role: ["Admin"
    //     // ,"Passenger"
    //   ]
    //}
  },
  {
    path: 'signIn',
    component: SignInComponent
  },
  {
    path: "error",
    component: ErrorComponent
  },
  {
    path: 'flight/seats',
    component: FlightSeatsComponent
  },
  {
    path: "users-tickets",
    component: UsersTicketsComponent
  },
  {
    path: 'create-flight',
    component: CreateFlightComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
