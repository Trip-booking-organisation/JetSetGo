import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {CreateTicketsRequest} from "../../flights/ui/model/CreateTicketsRequest";

@Injectable({
  providedIn: 'root'
})
export class CurrentTicketsService {
  private _currentTickets$: BehaviorSubject<CreateTicketsRequest> = new BehaviorSubject<CreateTicketsRequest>({
    flightId: '',
    newTickets: [],
    passengerId: '',
  })
  constructor() { }
  getCurrentTickets(): Observable<CreateTicketsRequest> {
    return this._currentTickets$.asObservable();
  }
  setCurrentTickets(tickets: CreateTicketsRequest) {
    this._currentTickets$.next(tickets);
  }
}
