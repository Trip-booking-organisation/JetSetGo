import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FlightsComponent} from "./ui/flights/flights.component";
import {FlightSeatsComponent} from './ui/flight-seats/flight-seats.component';
import {ComponentsModule} from "../components/components.module";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {SearchModule} from "../search/search.module";
import { PassengersComponent } from './ui/flight-seats/passengers/passengers.component';
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import { PlaneAnimationComponent } from './ui/plane-animation/plane-animation.component';
import { TicketComponent } from './ui/ticket/ticket.component';
import { TicketPrinterComponent } from './ui/ticket-printer/ticket-printer.component';


@NgModule({
  declarations: [FlightsComponent, FlightSeatsComponent, PassengersComponent,PlaneAnimationComponent, TicketComponent, TicketPrinterComponent],
    imports: [
        CommonModule,
        ComponentsModule,
        MatDividerModule,
        MatIconModule,
        MatInputModule,
        SearchModule,
        ReactiveFormsModule
    ],
  exports: [FlightsComponent]
})
export class FlightsModule {
}
