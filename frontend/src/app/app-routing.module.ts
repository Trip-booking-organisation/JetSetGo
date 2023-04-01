import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/ui/home/home.component";
import {FlightsComponent} from "./flights/ui/flights/flights.component";
import {SignInComponent} from "./autentification/view/sign-in/sign-in.component";
import {ErrorComponent} from './components/errors/errorPage/error.component';
import { UsersTicketsComponent } from './components/users-tickets/users-tickets.component';


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
