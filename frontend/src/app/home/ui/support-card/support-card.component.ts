import {Component, Input} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-support-card',
  templateUrl: './support-card.component.html',
  styleUrls: ['./support-card.component.scss']
})
export class SupportCardComponent {
  @Input()
  requirements: string = ''
  @Input()
  travelerNumber: string = ''
  @Input()
  description: string = ''
  @Input()
  color: string = ''

  constructor() {
    Aos.init({duration: 2000})
  }
}
