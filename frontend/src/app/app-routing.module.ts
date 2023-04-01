import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {SignInComponent} from "./autentification/view/sign-in/sign-in.component";
import {HasRoleGuard} from "./guards/roleGuard/has-role.guard";
import {IsAuthentificatedGuard} from "./guards/authentificationGuard/is-authentificated.guard";
import {ErrorComponent} from './components/errors/errorPage/error.component';
import {FlightSeatsComponent} from "./flights/ui/flight-seats/flight-seats.component";
import { UsersTicketsComponent } from './components/users-tickets/users-tickets.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'flights',
    component: FlightsComponent,
    canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    data: {
      role: ["Admin"
        // ,"Passenger"
      ]
    }
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
    path: 'flights/seats',
    component: FlightSeatsComponent
  },
  {
    path: "users-tickets",
    component: UsersTicketsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
