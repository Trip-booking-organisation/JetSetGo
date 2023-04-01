import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import {FlightsService} from "../shared/services/flights.service";
import {ToastrService} from "ngx-toastr";
import {map, Observable, startWith, Subscription} from "rxjs";
import {FlightResult} from "../shared/model/FlightResult";
import {flightsAutoComplete} from "./data-access/cityAndCountryData";
import {FlightAddress} from "./model/FlightAddress";
import {SearchQuery} from "./model/SearchQuery";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit, OnDestroy {
  searchResults!: FlightResult[];
  searchResults$!: Subscription;
  classSeats: string[] = ['First', 'Business', 'Economy'];
  flightControlFrom = new FormControl();
  flightControlTo = new FormControl();
  numberOfTravelers = new FormControl()
  date = new FormControl()
  flightsAddresses = flightsAutoComplete;
  filteredFlightsTo!: Observable<FlightAddress[]>;
  filteredFlightsFrom!: Observable<FlightAddress[]>;
  loadingState: string = 'init';
  isLoading!: boolean;

  constructor(private flightsService: FlightsService, private toast: ToastrService) {
  }

  ngOnInit(): void {
    this.mapFilterFrom()
    this.mapFilterTo()
  }

  private mapFilterTo() {
    this.filteredFlightsTo = this.flightControlTo.valueChanges
    .pipe(
      startWith(''),
      map(value => this._filterFlights(value))
    )
  }

  private mapFilterFrom() {
    this.filteredFlightsFrom = this.flightControlFrom.valueChanges
    .pipe(
      startWith(''),
      map(value => this._filterFlights(value))
    )
  }

  private _filterFlights(value: string): any[] {
    const filterValue = value.toLowerCase();
    return this.flightsAddresses.filter(flight => {
      const city = flight.city.toLowerCase();
      const country = flight.country.toLowerCase();
      return city.includes(filterValue) || country.includes(filterValue);
    });
  }

  searchFlights() {
    const from: string = this.flightControlFrom.value
    const to: string = this.flightControlTo.value
    const number = this.numberOfTravelers.value
    if (!from || !to || !number || !this.date.value) {
      this.toast.warning("Please enter search data!", "Search")
      return
    }
    this.isLoading = true
    const dateString = this.convertDateToString(new Date(this.date.value))
    const fromCity = from.split(',')[0].trim()
    const toCity = to.split(',')[0].trim()
    const fromCountry = from.split(',')[1].trim()
    const toCountry = to.split(',')[1].trim()
    const query: SearchQuery = {
      fromCity: fromCity,
      fromCountry: fromCountry,
      toCity: toCity,
      toCountry: toCountry,
      date: dateString,
      passengersNumber: number
    }
    this.searchResults$ = this.flightsService.searchFlights(query)
    .subscribe({
      next: (data: any) => {
        console.log(data)
        this.searchResults = data
        this.isLoading = false
      },
      error: (data: any) => {
        this.toast.error("Search error occurs!", "Search")
        this.isLoading = false
      }
    })
  }

  convertDateToString(date: Date) {
    const formattedDate: string = date.toLocaleDateString('en-US').replace(/\//g, '-');
    return formattedDate
  }

  filterClass(flightClass: string) {
    const filter = this.searchResults
    .filter(f => f.seats.filter(s => s.class.toLowerCase().includes(flightClass)))
    this.searchResults = [...filter]
  }

  ngOnDestroy(): void {
    //this.searchResults$.unsubscribe();
  }
}
