import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CreateFlightComponent} from './ui/create-flight.component';
import {MatStepperModule} from "@angular/material/stepper";
import {SelectAddressComponent} from './ui/select-address/select-address.component';
import {SelectDatesComponent} from './ui/select-dates/select-dates.component';
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import {MatAutocompleteModule} from "@angular/material/autocomplete";
import {MatNativeDateModule} from "@angular/material/core";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {CreateSeatComponent} from './ui/create-seat/create-seat.component';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatCardModule} from "@angular/material/card";
import {MatSelectModule} from "@angular/material/select";
import {CreateMultiSeatsComponent} from './ui/create-multi-seats/create-multi-seats.component';
import {AdditionalInfoComponent} from './ui/additional-info/additional-info.component';


@NgModule({
  declarations: [
    CreateFlightComponent,
    SelectAddressComponent,
    SelectDatesComponent,
    CreateSeatComponent,
    CreateMultiSeatsComponent,
    AdditionalInfoComponent
  ],
  exports: [
    CreateFlightComponent,
    CreateSeatComponent
  ],
  imports: [
    CommonModule,
    MatStepperModule,
    MatInputModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatSlideToggleModule,
    MatCardModule,
    MatSelectModule,
  ]
})
export class CreateFlightModule {
}
