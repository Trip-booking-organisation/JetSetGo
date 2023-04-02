import {Component, OnInit} from '@angular/core';
import {FlightResult} from "../../../shared/model/FlightResult";
import {CurrentFlightService} from "../../../shared/services/current-flight.service";
import {CreateTicketInfoRequest} from "../model/CreateTicketInfoRequest";
import {CreateTicketsRequest} from "../model/CreateTicketsRequest";
import {TokenStorageService} from "../../../shared/services/tokenStorage.service";
import {TicketsService} from "../../../shared/services/ticketService";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-flight-seats',
  templateUrl: './flight-seats.component.html',
  styleUrls: ['./flight-seats.component.scss']
})
export class FlightSeatsComponent implements OnInit {
  currentFlight!: FlightResult
  numberOfTravelers = 1;
  listOfSeats: string[] =[];
  listOfContacts: string[]=[];
  price = 0;

  constructor(private currentFlightService: CurrentFlightService,
              private  tokenStorage: TokenStorageService,
              private ticketService: TicketsService,
              private toasterService: ToastrService) {
  }

  ngOnInit(): void {
    this.currentFlightService.getCurrentFlight().subscribe(
      (flight: FlightResult) => {
        this.currentFlight = flight;
        this.numberOfTravelers = this.currentFlightService.getNumberOfTravelers();
      }
    );
  }

  addSeat($event: any) {
    let seat = false;
    this.listOfSeats.forEach(seatNumber =>{
      if (seatNumber === $event.seatNumber)
        seat = true;
    })
    if(seat){
      const newList = this.listOfSeats.filter(value => value != $event.seatNumber)
      this.listOfSeats = [...newList]
    }else
    this.listOfSeats.push($event.seatNumber);
  }

  addContactInfo($event: any) {
    this.listOfContacts.push($event);
  }
  onBuy(){
    if (this.listOfContacts.length != this.numberOfTravelers){
      this.toasterService.warning("You haven't filled out all contact informations!");
       return;
    }
    if (this.listOfSeats.length != this.numberOfTravelers) {
      this.toasterService.warning("You must choose " + this.numberOfTravelers + " seats!");
      return;
    }
    const objects = this.listOfSeats
      .map((seatNumber, index) => ({seatNumber, contactDetails: this.listOfContacts[index]}));
    const newTickets = this.createRequest(objects);
    this.ticketService.createTickets(newTickets).subscribe({
      next: response =>{
        console.log(response)
    }
    })
  }

  private createRequest(objects: { contactDetails: string; seatNumber: string }[]) {
    const ticketInfoList: CreateTicketInfoRequest[] = []
    objects.forEach(object => {
      let ticketInfoRequest: CreateTicketInfoRequest = {
        seatNumber: object.seatNumber,
        contactDetails: object.contactDetails
      }
      ticketInfoList.push(ticketInfoRequest)
    })
    const newTickets: CreateTicketsRequest = {
      flightId: this.currentFlight.id,
      passengerId: this.tokenStorage.getUser().id,
      newTickets: ticketInfoList
    }
    return newTickets;
  }
}
