import {CreateTicketInfoRequest} from "./CreateTicketInfoRequest";

export interface CreateTicketsRequest{
  flightId:string,
  passengerId : string,
  newTickets : CreateTicketInfoRequest[]
}
