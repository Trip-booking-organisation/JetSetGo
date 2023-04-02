import { Component } from '@angular/core';

@Component({
  selector: 'app-passengers',
  templateUrl: './passengers.component.html',
  styleUrls: ['./passengers.component.scss']
})
export class PassengersComponent {
  counter=0;
  array=[1,2,3];

  getIcon(number:number) {
    if(this.counter>7) {

      return `assets/people-icons/1.png`;
    }
    this.counter = number;
    return `assets/people-icons/${this.counter}.png`;
  }
}
