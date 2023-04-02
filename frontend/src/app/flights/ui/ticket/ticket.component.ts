import {Component, Input, OnInit} from '@angular/core';
import {FlightResult} from "../../../shared/model/FlightResult";
import {CreateTicketInfoRequest} from "../model/CreateTicketInfoRequest";

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit{
  @Input() flight!: FlightResult
  @Input()  ticketDetails!: CreateTicketInfoRequest
  constructor() {
  }
  ngOnInit(): void {

  }

}
