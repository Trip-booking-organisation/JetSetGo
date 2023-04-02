import { Address } from "./Address";
import { FlightDetails } from "./FlightDetails";

export interface UsersTicketResult {
  contactDetails:string
  seatNumber: string
  bookingTime: Date
  departure: FlightDetails
  arrival: FlightDetails
    
  }
  