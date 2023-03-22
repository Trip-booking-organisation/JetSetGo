import {Component} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-lounge',
  templateUrl: './lounge.component.html',
  styleUrls: ['./lounge.component.scss']
})
export class LoungeComponent {
  constructor() {
    Aos.init({duration: 2000})
  }
}
