import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {map, Observable} from "rxjs";
import {MatStepper, StepperOrientation} from '@angular/material/stepper';
import {BreakpointObserver} from "@angular/cdk/layout";
import {CreateFlight} from "../model/create-flight.model";
import {SeatCreate} from "../model/seat-create.model";
import {FlightsService} from "../../shared/services/flights.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

const TIME_REGEX = /^([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$/;

@Component({
  selector: 'app-create-flight',
  templateUrl: './create-flight.component.html',
  styleUrls: ['./create-flight.component.scss']
})
export class CreateFlightComponent implements OnInit {
  stepOneForm!: FormGroup;
  stepTwoForm!: FormGroup;
  stepFourForm!: FormGroup;
  animationDuration: string = "1500"
  stepperOrientation: Observable<StepperOrientation>;
  stepper: MatStepper | undefined;
  seats: SeatCreate[] = []

  constructor(private fb: FormBuilder, breakpointObserver: BreakpointObserver,
              private flightsService: FlightsService, private toastService: ToastrService,
              private router: Router) {
    this.stepperOrientation = breakpointObserver
    .observe('(min-width: 1000px)')
    .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));
  }

  ngOnInit() {
    this.stepOneForm = this.fb.group({
      departureLocation: ['', Validators.required],
      arrivalLocation: ['', Validators.required]
    });
    this.stepTwoForm = this.fb.group({
      departureDate: [null, Validators.required],
      departureTime: ['', [Validators.required, this.timeFormatValidator()]],
      arrivalDate: [null, Validators.required],
      arrivalTime: ['', [Validators.required, this.timeFormatValidator()]],
    });
    this.stepFourForm = this.fb.group({
      companyName: ['', Validators.required],
      departureAirportName: ['', Validators.required],
      arrivalAirportName: ['', Validators.required],
    })
  }

  timeFormatValidator() {
    return (control: FormControl) => {
      const value = control.value;
      if (value && !TIME_REGEX.test(value)) {
        return {invalidFormat: true};
      }
      return null;
    };
  }

  nextStep(stepper: MatStepper) {
    this.stepper = stepper;
    this.stepper.next()
  }

  prevStep(stepper: MatStepper) {
    this.stepper = stepper;
    this.stepper.previous()
  }

  seatsEvent(seatsNew: SeatCreate[], stepper: MatStepper) {
    this.seats = seatsNew
    this.stepper = stepper;
    this.stepper.next()
  }

  createFlight() {
    const departureDate = this.convertDateToString(this.stepTwoForm.get('departureDate')?.value)
    const arrivalDate = this.convertDateToString(this.stepTwoForm.get('arrivalDate')?.value)
    const airportNameArrival = this.stepFourForm.get('arrivalAirportName')?.value
    const departureNameArrival = this.stepFourForm.get('departureAirportName')?.value
    const departureTime = this.stepTwoForm.get('departureTime')?.value
    const arrivalTime = this.stepTwoForm.get('arrivalTime')?.value
    const company = this.stepFourForm.get('companyName')?.value
    const from = this.stepOneForm.get('departureLocation')?.value
    const to = this.stepOneForm.get('arrivalLocation')?.value
    const fromCity = from.split(',')[0].trim()
    const toCity = to.split(',')[0].trim()
    const fromCountry = from.split(',')[1].trim()
    const toCountry = to.split(',')[1].trim()
    const flight: CreateFlight = {
      arrival: {
        address: {
          city: toCity,
          country: toCountry,
          latitude: 0,
          longitude: 0,
          airportName: airportNameArrival
        },
        date: arrivalDate,
        time: arrivalTime
      },
      departure: {
        address: {
          city: fromCity,
          country: fromCountry,
          latitude: 0,
          longitude: 0,
          airportName: departureNameArrival
        },
        date: departureDate,
        time: departureTime
      },
      companyName: company,
      seats: this.seats
    }
    console.log(flight)
    this.flightsService.createFlight(flight).subscribe({
      next: _ => {
        this.toastService.success("You are successfully created flight!", "Success")
        this.router.navigate(['flights']).then()
      },
      error: err => {
        this.toastService.error(err.errors, "Error")
      }
    })
  }

  convertDateToString(date: string) {
    const inputDate = new Date(date);
    const year = inputDate.getFullYear();
    const month = inputDate.getMonth();
    const day = inputDate.getDate() + 1;
    const dateOnly = new Date(year, month, day).toISOString().substring(0, 10);
    console.log(dateOnly);
    return dateOnly;
  }
}
