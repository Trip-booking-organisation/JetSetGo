import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {FlightsService} from "./home/data-access/flights.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  hello$!: Observable<string>;
  title = 'frontend';

  constructor(private service: FlightsService) {
  }

  ngOnInit(): void {
    this.hello$ = this.service.getAllFlights();
  }
}
