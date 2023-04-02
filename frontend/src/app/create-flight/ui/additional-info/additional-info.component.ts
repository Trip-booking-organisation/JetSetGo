import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-additional-info',
  templateUrl: './additional-info.component.html',
  styleUrls: ['../scss/step-styles.scss']
})
export class AdditionalInfoComponent implements OnInit {
  @Input() stepControl!: FormGroup;
  @Output() nextClick = new EventEmitter<void>()
  @Output() prevClick = new EventEmitter<void>()

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.stepControl.addControl('companyName', this.fb.control('', Validators.required));
    this.stepControl.addControl('departureAirportName', this.fb.control('', Validators.required));
    this.stepControl.addControl('arrivalAirportName', this.fb.control('', Validators.required));
  }

  emitEventNext() {
    this.nextClick.emit()
  }

  emitEventBack() {
    this.prevClick.emit()
  }

}
