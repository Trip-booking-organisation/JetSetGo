import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FlightsComponent} from "./ui/flights/flights.component";
import { FlightSeatsComponent } from './ui/flight-seats/flight-seats.component';
import {ComponentsModule} from "../components/components.module";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";


@NgModule({
  declarations: [FlightsComponent, FlightSeatsComponent],
  imports: [
    CommonModule,
    ComponentsModule,
    MatDividerModule,
    MatIconModule
  ],
  exports: [FlightsComponent]
})
export class FlightsModule {
}
