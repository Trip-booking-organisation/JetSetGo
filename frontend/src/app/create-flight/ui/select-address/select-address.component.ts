import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {flightsAutoComplete} from "../../../search/data-access/cityAndCountryData";
import {map, Observable, startWith} from "rxjs";
import {FlightAddress} from "../../../search/model/FlightAddress";

@Component({
  selector: 'app-select-address',
  templateUrl: './select-address.component.html',
  styleUrls: ['../scss/step-styles.scss']
})
export class SelectAddressComponent implements OnInit {
  @Input() stepControl!: FormGroup;
  flightsAddresses = flightsAutoComplete;
  filteredFlightsTo!: Observable<FlightAddress[]>;
  filteredFlightsFrom!: Observable<FlightAddress[]>;
  @Output() nextClick = new EventEmitter<void>()

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.stepControl.addControl('departureLocation', this.fb.control('', Validators.required));
    this.stepControl.addControl('arrivalLocation', this.fb.control('', Validators.required));
    this.mapFilterFrom()
    this.mapFilterTo()
  }

  private mapFilterTo() {
    this.filteredFlightsTo = this.stepControl.get('arrivalLocation')!.valueChanges
    .pipe(
      startWith(''),
      map(value => this._filterFlights(value))
    )
  }

  private mapFilterFrom() {
    this.filteredFlightsFrom = this.stepControl.get('departureLocation')!.valueChanges
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

  emitEvent() {
    this.nextClick.emit()
  }
}
