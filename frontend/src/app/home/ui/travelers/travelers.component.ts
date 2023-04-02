import {Component} from '@angular/core';
import {Traveler} from "../../model/Traveler";
import {travelersData} from "../../data-access/travelers-data";

@Component({
  selector: 'app-travelers',
  templateUrl: './travelers.component.html',
  styleUrls: ['./travelers.component.scss']
})
export class TravelersComponent {
  travelers: Traveler[] = travelersData;

  constructor() {
  }
}
