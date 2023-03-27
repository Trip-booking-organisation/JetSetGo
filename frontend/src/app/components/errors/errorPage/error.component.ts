import { Component } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import * as Aos from "aos";

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent {
  errorExplanation = "error"
  constructor(private route: ActivatedRoute) {
    Aos.init({duration: 2000})
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params=>{
      this.errorExplanation = params['errorExplanation']
    })
  }
}
