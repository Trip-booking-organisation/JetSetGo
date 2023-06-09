import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {SignInComponent} from "./autentification/view/sign-in/sign-in.component";
import {ErrorComponent} from './components/errors/errorPage/error.component';
import {FlightSeatsComponent} from "./flights/ui/flight-seats/flight-seats.component";
import {UsersTicketsComponent} from './components/users-tickets/users-tickets.component';
import {CreateFlightComponent} from "./create-flight/ui/create-flight.component";
import {HasRoleGuard} from "./guards/roleGuard/has-role.guard";
import {IsAuthentificatedGuard} from "./guards/authentificationGuard/is-authentificated.guard";
import {TicketPrinterComponent} from "./flights/ui/ticket-printer/ticket-printer.component";


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'flights',
    component: FlightsComponent
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
    component: FlightSeatsComponent,
    canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    data: {
      role: ["Passenger"]
    }
  },
  {
    path: "users-tickets",
    component: UsersTicketsComponent,
    canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    data: {
      role: ["Passenger"]
    }

  },
  {
    path: "your-tickets",
    component: TicketPrinterComponent,
    canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    data: {
      role: ["Passenger"]
    }
  },
  {
    path: 'create-flight',
    component: CreateFlightComponent,
    canActivate: [IsAuthentificatedGuard, HasRoleGuard],
    data: {
      role: ["Admin"]
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
