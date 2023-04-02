import {SeatClass} from "../../shared/model/seat-class.model";

export interface SeatCreate {
  seatNumber: string,
  available: boolean,
  price: number,
  class: SeatClass
}
