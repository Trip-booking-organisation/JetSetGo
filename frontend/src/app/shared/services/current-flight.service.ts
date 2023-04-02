import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {FlightResult} from "../model/FlightResult";

@Injectable({
  providedIn: 'root'
})
export class CurrentFlightService {
  private _currentFlight$: BehaviorSubject<FlightResult> = new BehaviorSubject<FlightResult>({
    companyName: '',
    seats: [],
    departureAddress: {airportName: '', city: '', country: '', latitude: 0, longitude: 0},
    totalTicketPrize: 0,
    arrivalAddress: {airportName: '', city: '', country: '', latitude: 0, longitude: 0},
    arrivalDate: new Date(),
    arrivalTime: new Date(),
    id: "",
    departureTime: new Date(),
    departureDate: new Date()
  });
  private numberOfTravelers = 1;

  getCurrentFlight(): Observable<FlightResult> {
    return this._currentFlight$.asObservable();
  }
  getNumberOfTravelers(){
    return this.numberOfTravelers;
  }
  setNumberOfTravelers(numberOfTravelers: number){
     this.numberOfTravelers = numberOfTravelers;
  }

  setCurrentFlight(flight: FlightResult) {
    this._currentFlight$.next(flight);
  }

  constructor() {

  }
}
