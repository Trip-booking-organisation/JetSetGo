import {Component} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent {
  constructor() {
    Aos.init({duration: 2000})
  }
}
