import {Component, OnInit} from '@angular/core';
import {CurrentTicketsService} from "../../../shared/services/current-tickets.service";
import {CreateTicketsRequest} from "../model/CreateTicketsRequest";
import {CurrentFlightService} from "../../../shared/services/current-flight.service";
import {FlightResult} from "../../../shared/model/FlightResult";

@Component({
  selector: 'app-ticket-printer',
  templateUrl: './ticket-printer.component.html',
  styleUrls: ['./ticket-printer.component.scss']
})
export class TicketPrinterComponent implements OnInit{
  currentTickets! : CreateTicketsRequest
  currentFlight!: FlightResult
  constructor(private ticketsSave: CurrentTicketsService,
              private flightSave: CurrentFlightService) {
    this.flightSave.getCurrentFlight().subscribe(
      (flight: FlightResult) => {
        this.currentFlight = flight;
        console.log(this.currentFlight)
      }
    );
  }
  ngOnInit(): void {
    this.ticketsSave.getCurrentTickets().subscribe(
      (tickets: CreateTicketsRequest) => {
        this.currentTickets = tickets;
      })
  }

}
