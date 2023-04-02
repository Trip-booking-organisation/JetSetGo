import {Component, EventEmitter, Output} from '@angular/core';
import {ToastrService} from "ngx-toastr";
import {SeatCreate} from "../../model/seat-create.model";
import {SeatClass} from "../../../shared/model/seat-class.model";

@Component({
  selector: 'app-create-multi-seats',
  templateUrl: './create-multi-seats.component.html',
  styleUrls: ['../scss/step-styles.scss']
})
export class CreateMultiSeatsComponent {
  seats: SeatCreate[] = [];
  @Output() nextClick = new EventEmitter<SeatCreate[]>()
  @Output() prevClick = new EventEmitter<void>()


  constructor(private toast: ToastrService) {
  }

  emitEventNext() {
    if (this.seats.length === 0) {
      this.toast.error("Please create atleast one seat")
      return
    }
    this.nextClick.emit(this.seats)
  }

  emitEventBack() {
    this.prevClick.emit()
  }

  addSeat(seat: SeatCreate) {
    this.seats = [...this.seats, seat]
  }

  removeSeat(index: number) {
    this.seats.splice(index, 1);
  }

  switchClassBack(className: SeatClass) {
    let classPlane = "Economy"
    switch (className) {
      case SeatClass.Economy:
        classPlane = "Economy"
        break;
      case SeatClass.Business:
        classPlane = "Business"
        break;
      case SeatClass.First:
        classPlane = "First Class"
        break;
    }
    return classPlane
  }
}
