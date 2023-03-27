import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import * as Aos from 'aos';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('planeVideo') myVideo!: ElementRef;

  constructor() {
    Aos.init({duration: 2000})
  }

  ngOnInit(): void {
  }

  playVideo() {
    console.log(this.myVideo)
    this.myVideo.nativeElement.play();
  }
}
