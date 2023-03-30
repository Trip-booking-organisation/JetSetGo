import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {FlightResult} from "../model/FlightResult";

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  private baseUrl = `${environment.baseUrl}/api/v1/flights`

  constructor(private readonly httpClient: HttpClient) {
  }

  public searchFlights(locationFrom: string, locationTo: string,
                       passengersNumber: number, date: string): Observable<FlightResult[]> {
    return this.httpClient
    .get<FlightResult[]>(`${this.baseUrl}/search?locationFrom=${locationFrom}&locationTo=${locationTo}&passengersNumber=${passengersNumber}&date=${date}`);
  }
}
