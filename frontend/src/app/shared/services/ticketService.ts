import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { UsersTicketResult } from '../model/UsersTicketResult';
import {CreateTicketsRequest} from "../../flights/ui/model/CreateTicketsRequest";


@Injectable({
  providedIn: 'root'
})
export class TicketsService {
  private baseUrl = `${environment.baseUrl}/api/v1/tickets`

  constructor(private readonly httpClient: HttpClient) {
  }

  public getAllTicketsByPassenger(userId: string): Observable<UsersTicketResult[]> {
    return this.httpClient
    .get<UsersTicketResult[]>(`${this.baseUrl}/` + userId);
  }

  public createTickets(tickets:CreateTicketsRequest):Observable<any>{
    return this.httpClient.post(`${this.baseUrl}/`,tickets);
  }
}
