import {CreateTicketInfoRequest} from "./CreateTicketInfoRequest";

export interface CreateTicketsRequest{
  apiKey?: string
  flightId:string,
  passengerId : string,
  newTickets : CreateTicketInfoRequest[]
}
