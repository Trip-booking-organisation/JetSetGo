import {Component, OnInit} from '@angular/core';
import {FlightResult} from "../../../shared/model/FlightResult";
import {CurrentFlightService} from "../../../shared/services/current-flight.service";

@Component({
  selector: 'app-flight-seats',
  templateUrl: './flight-seats.component.html',
  styleUrls: ['./flight-seats.component.scss']
})
export class FlightSeatsComponent implements OnInit {
  currentFlight!: FlightResult

  constructor(private currentFlightService: CurrentFlightService) {
  }

  numbers = [0, 1];

  ngOnInit(): void {
    this.currentFlightService.getCurrentFlight().subscribe(
      (flight: FlightResult) => {
        this.currentFlight = flight;
      }
    );
    console.log(this.currentFlight)
  }

}
