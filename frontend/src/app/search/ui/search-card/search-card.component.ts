import {Component, Input} from '@angular/core';
import {FlightResult} from "../../../shared/model/FlightResult";

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss']
})
export class SearchCardComponent {
  @Input() flight!: FlightResult;

  public filterSeats(classValue: string): number {
    const bs = this.flight.seats.filter(value => value.class.includes(classValue))
    if (bs.length === 0) {
      return 0
    }
    return bs.map(value => value.price)[0]
  }
}
