import {FlightDetails} from "./flight-details.model";
import {SeatCreate} from "./seat-create.model";

export interface CreateFlight {
  seats: SeatCreate[],
  departure: FlightDetails,
  arrival: FlightDetails,
  companyName: string
}
