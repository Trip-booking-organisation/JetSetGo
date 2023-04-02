import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

const TIME_REGEX = /^([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$/;

@Component({
  selector: 'app-select-dates',
  templateUrl: './select-dates.component.html',
  styleUrls: ['../scss/step-styles.scss']
})
export class SelectDatesComponent implements OnInit {
  @Input() stepControl!: FormGroup;
  @Output() nextClick = new EventEmitter<void>()
  @Output() prevClick = new EventEmitter<void>()

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.stepControl.addControl('departureTime', this.fb.control('',
      [Validators.required, this.timeFormatValidator()]));
    this.stepControl.addControl('departureDate', this.fb.control(null, Validators.required));
    this.stepControl.addControl('arrivalDate', this.fb.control(null, Validators.required));
    this.stepControl.addControl('arrivalTime', this.fb.control('',
      [Validators.required, this.timeFormatValidator()]));
  }

  timeFormatValidator() {
    return (control: FormControl) => {
      const value = control.value;
      if (value && !TIME_REGEX.test(value)) {
        console.log('Invalid')
        return {invalidFormat: true};
      }
      return null;
    };
  }

  emitEventNext() {
    this.nextClick.emit()
  }

  emitEventBack() {
    this.prevClick.emit()
  }
}
