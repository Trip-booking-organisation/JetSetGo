import {Component} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  searchForm = new FormGroup({
    from: new FormControl<string>(''),
    to: new FormControl<string>(''),
    numberOfTravelers: new FormControl(0),
    date: new FormControl()
  });

  constructor() {
  }

  searchFlights() {
    console.log(this.searchForm.get('from')?.value);
    console.log(this.searchForm.get('to')?.value);
    console.log(this.searchForm.get('numberOfTravelers')?.value);
    console.log(this.searchForm.get('date')?.value);
  }
}
