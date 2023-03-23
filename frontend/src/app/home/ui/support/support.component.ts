import {Component} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.scss']
})
export class SupportComponent {

  constructor() {
    Aos.init({duration: 2000})
  }
}
