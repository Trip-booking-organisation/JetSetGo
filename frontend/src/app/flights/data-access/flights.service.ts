import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class FlightsService {

  constructor(private client: HttpClient) {
  }

  public getAllFlights(): Observable<any> {
    return this.client.get(environment.baseUrl)
  }
}
