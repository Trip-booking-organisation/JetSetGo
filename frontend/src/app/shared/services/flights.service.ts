import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  private baseUrl = `${environment.baseUrl}/api/v1/flights`

  constructor(private readonly httpClient: HttpClient) {
  }

  public searchFlights(locationFrom: string, locationTo: string,
                       passengersNumber: number, date: string) {

  }
}
