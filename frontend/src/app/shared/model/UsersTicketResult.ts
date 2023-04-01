import { Address } from "./Address";

export interface UsersTicketResult {
    seatNumber: string,
    bookingTime: Date,
    contactDetails: string,
    departureAddress: Address,
    arrivalAddress: Address,
    departureTime: Date,
    arrivalTime: Date,
    departureDate: Date,
    arrivalDate: Date
    
  }
  