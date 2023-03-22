import {Component} from '@angular/core';
import * as Aos from "aos";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  constructor() {
    Aos.init({duration: 2000})
  }
}
