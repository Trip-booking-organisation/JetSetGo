import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {FlightResult} from "../model/FlightResult";
import {SearchQuery} from "../../search/model/SearchQuery";
import {CreateFlight} from "../../create-flight/model/create-flight.model";

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  private baseUrl = `${environment.baseUrl}/api/v1/flights`

  constructor(private readonly httpClient: HttpClient) {
  }

  public searchFlights(query: SearchQuery): Observable<FlightResult[]> {
    return this.httpClient
    .get<FlightResult[]>(`${this.baseUrl}/search?cityFrom=${query.fromCity}&countryFrom=${query.fromCountry}&cityTo=${query.toCity}&countryTo=${query.toCountry}&passengersNumber=${query.passengersNumber}&date=${query.date}`);
  }

  public createFlight(flight: CreateFlight): Observable<any> {
    return this.httpClient.post(this.baseUrl, flight);
  }
}
