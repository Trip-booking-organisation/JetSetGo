import {Seat} from "./Seat";
import {Address} from "./Address";

export interface FlightResult {
  id: string,
  totalTicketPrize: number,
  seats: Seat[],
  departureAddress: Address,
  arrivalAddress: Address,
  departureTime: Date,
  departureDate: Date,
  arrivalTime: Date,
  arrivalDate: Date,
}
