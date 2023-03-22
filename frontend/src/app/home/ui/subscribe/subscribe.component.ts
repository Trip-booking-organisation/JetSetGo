import {Component} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.scss']
})
export class SubscribeComponent {
  constructor() {
    Aos.init({duration: 2000})
  }
}
