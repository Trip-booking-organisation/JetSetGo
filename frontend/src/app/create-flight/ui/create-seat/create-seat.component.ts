import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {animate, state, style, transition, trigger} from "@angular/animations";
import {SeatCreate} from "../../model/seat-create.model";
import {SeatClass} from "../../../shared/model/seat-class.model";

@Component({
  selector: 'app-create-seat',
  templateUrl: './create-seat.component.html',
  styleUrls: ['../scss/step-styles.scss'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translateY(0)',
        opacity: 1
      })),
      transition('in => out', [
        style({
          transform: 'translateX(100%)',
          opacity: 0
        }),
        animate('1000ms ease-in')
      ]),
      transition('out => in', [
        animate('1000ms ease-out', style({
          transform: 'translateX(-100%)',
          opacity: 0
        }))
      ])
    ])
  ]
})
export class CreateSeatComponent {
  @Output() seatAdded = new EventEmitter<SeatCreate>();
  slideState = 'in';
  cnt: number = 0

  seatForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.seatForm = this.fb.group({
      seatNumber: ['', Validators.required],
      price: ['', Validators.required],
      class: ['', Validators.required],
    });
  }

  addSeat() {
    if (this.seatForm.valid) {
      const newSeat: SeatCreate = {
        seatNumber: this.seatForm.get('seatNumber')!.value,
        available: true,
        price: this.seatForm.get('price')!.value,
        class: this.switchClass(this.seatForm.get('class')!.value),
      };

      this.seatAdded.emit(newSeat);
      this.resetAnimation()
      this.seatForm.reset();
    } else {
      this.seatForm.markAllAsTouched();
    }
  }

  switchClass(className: string) {
    let classPlane = SeatClass.Economy
    switch (className) {
      case "Economy":
        classPlane = SeatClass.Economy
        break;
      case "Business":
        classPlane = SeatClass.Business
        break;
      case "First Class":
        classPlane = SeatClass.First
        break;
    }
    return classPlane
  }

  resetAnimation() {
    this.cnt = this.cnt + 1
    if (this.cnt % 2 === 0) {
      this.slideState = 'in';
    } else {
      this.slideState = 'out';
    }
  }
}
