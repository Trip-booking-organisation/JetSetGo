import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {FlightsService} from "../shared/services/flights.service";
import {ToastrService} from "ngx-toastr";
import {Subscription} from "rxjs";
import {FlightResult} from "../shared/model/FlightResult";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit, OnDestroy {
  searchResults!: FlightResult[];
  searchResults$!: Subscription;
  classSeats: string[] = ['First', 'Business', 'Economy'];
  searchForm = new FormGroup({
    from: new FormControl<string>(''),
    to: new FormControl<string>(''),
    numberOfTravelers: new FormControl(0),
    date: new FormControl()
  });

  constructor(private flightsService: FlightsService, private toast: ToastrService) {
  }

  searchFlights() {
    const from = this.searchForm.get('from')?.value
    const to = this.searchForm.get('to')?.value
    const number = this.searchForm.get('numberOfTravelers')?.value
    const date = this.searchForm.get('date')?.value
    console.log(date)
    if (!from || !to || !number || !date) {
      this.toast.info("Please enter search data!", "Search")
      return
    }
    this.searchResults$ = this.flightsService.searchFlights(from, to, number, date)
    .subscribe({
      next: (data: any) => {
        console.log(data)
        this.searchResults = data
      },
      error: (data: any) => {
        this.toast.error("Search error occurs!", "Search")
      }
    })
  }

  filterClass(flightClass: string) {
    const filter = this.searchResults
    .filter(f => f.seats.filter(s => s.class.toLowerCase().includes(flightClass)))
    this.searchResults = [...filter]
  }

  ngOnDestroy(): void {
    this.searchResults$.unsubscribe();
  }

  ngOnInit(): void {
  }
}
