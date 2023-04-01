import { Component } from '@angular/core';

@Component({
  selector: 'app-rounded-rectangle',
  templateUrl: './rounded-rectangle.component.html',
  styleUrls: ['./rounded-rectangle.component.scss']
})
export class RoundedRectangleComponent {
clicked = false;
  addSeat() {
    console.log("1A");
    this.clicked = true;
  }
}
