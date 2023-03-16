import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {FlightsService} from "../../data-access/flights.service";

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit {
  flights$!: Observable<any>;

  constructor(private service: FlightsService) {
  }

  ngOnInit(): void {
    this.flights$ = this.service.getAllFlights()
  }

}
