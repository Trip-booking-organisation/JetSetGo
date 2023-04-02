import {Component, Input} from '@angular/core';
import {Router} from '@angular/router';
import {FlightResult} from "../../../shared/model/FlightResult";
import {CurrentFlightService} from "../../../shared/services/current-flight.service";

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss']
})
export class SearchCardComponent {
  @Input() flight!: FlightResult;
  @Input() numberOfTravelers=1;


  constructor(private flightSave: CurrentFlightService, private router: Router) {

  }

  public filterSeats(classValue: string): number {
    const bs = this.flight.seats.filter(value => value.class.includes(classValue))
    if (bs.length === 0) {
      return 0
    }
    return bs.map(value => value.price)[0]
  }

  navigateToBook() {
    this.flightSave.setCurrentFlight(this.flight)
    this.flightSave.setNumberOfTravelers(this.numberOfTravelers);
    this.router.navigate(['flight/seats']).then()
  }
}
