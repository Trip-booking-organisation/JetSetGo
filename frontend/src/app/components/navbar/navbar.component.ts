import {Component, EventEmitter, HostListener, OnInit, Output} from '@angular/core';
import {navData} from "./passenger-nav-data";
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  activeClass: string = 'navbar-menu';
  addBackground: string = 'navbar-two';
  isCollapsed: boolean = false
  navDataPassenger = navData;



  constructor(private router: Router){}
  ngOnInit(): void {
  }

  showNavBar() {
    this.activeClass = this.isCollapsed ? 'navbar-menu' : 'navbar-menu show-nav';
    this.isCollapsed = !this.isCollapsed
  }

  @HostListener('window:scroll', ['$event'])
  addBg() {
    this.addBackground = window.scrollY >= 15
      ? 'navbar-two nav-bg'
      : 'navbar-two';
  }

  removeNavBar() {
    this.activeClass = 'navbar-menu'
  }

  goToSignIn() {
    this.router.navigate(['signIn']).then();
  }
}
