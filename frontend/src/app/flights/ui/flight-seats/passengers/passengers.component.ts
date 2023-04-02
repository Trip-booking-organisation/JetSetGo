import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-passengers',
  templateUrl: './passengers.component.html',
  styleUrls: ['./passengers.component.scss']
})
export class PassengersComponent  implements OnInit{
  counter=0;
  array: number[]=[];
  @Input() numberOfTravelers = 1;
  contactFormControl= new FormControl('',Validators.required);
  @Output() eventEmitter: EventEmitter<any> = new EventEmitter<any>();
  ngOnInit(): void {
    if(this.numberOfTravelers == undefined)
      this.numberOfTravelers = 1;
    this.generateArray(this.numberOfTravelers);
    console.log(this.array);
  }
  public generateArray(n: number): void {
    this.array = Array.from({ length: n }, (_, i) => i + 1);
  }
  getIcon(number:number) {
    if(this.counter>7) {

      return `assets/people-icons/1.png`;
    }
    this.counter = number;
    return `assets/people-icons/${this.counter}.png`;
  }


  onTextEntered() {
    console.log(this.contactFormControl.value)
    this.eventEmitter.emit(this.contactFormControl.value)
  }
}
