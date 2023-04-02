import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from "rxjs";
import {FlightsService} from "../../../shared/services/flights.service";
import {FlightResult} from "../../../shared/model/FlightResult";

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit, OnDestroy {
  flights$!: Subscription;
  flights: FlightResult[] = [];

  constructor(private service: FlightsService) {
  }

  ngOnInit(): void {
    this.flights$ = this.service.getAllFlights().subscribe({
      next: value => {
        this.flights = value
      }
    })
  }

  ngOnDestroy(): void {
    this.flights$.unsubscribe()
  }

}
