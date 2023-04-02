import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FlightsComponent} from "./ui/flights/flights.component";
import {FlightSeatsComponent} from './ui/flight-seats/flight-seats.component';
import {ComponentsModule} from "../components/components.module";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {SearchModule} from "../search/search.module";
import { PlaneAnimationComponent } from './ui/plane-animation/plane-animation.component';
import { TicketComponent } from './ui/ticket/ticket.component';
import { TicketPrinterComponent } from './ui/ticket-printer/ticket-printer.component';


@NgModule({
  declarations: [FlightsComponent, FlightSeatsComponent, PlaneAnimationComponent, TicketComponent, TicketPrinterComponent],
  imports: [
    CommonModule,
    ComponentsModule,
    MatDividerModule,
    MatIconModule,
    SearchModule
  ],
  exports: [FlightsComponent]
})
export class FlightsModule {
}
