import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Seat} from "../../shared/model/Seat";

@Component({
  selector: 'app-rounded-rectangle',
  templateUrl: './rounded-rectangle.component.html',
  styleUrls: ['./rounded-rectangle.component.scss']
})
export class RoundedRectangleComponent {
clicked = false;
@Input() seat!: Seat;
@Output() eventEmitter: EventEmitter<any> = new EventEmitter<any>();
  addSeat() {
    this.clicked = !this.clicked;
    this.eventEmitter.emit(this.seat);
  }
}
