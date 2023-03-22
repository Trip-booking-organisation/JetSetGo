import {Component, EventEmitter, HostListener, OnInit, Output} from '@angular/core';
import {navData} from "./passenger-nav-data";
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {SignInComponent} from "../../view/autentification/sign-in/sign-in.component";

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
  navbar_one = document.querySelector(".navbar-one");


  constructor(private router: Router,private route: ActivatedRoute){
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.handleColorTransparancy();
      }
    });
  }
  ngOnInit(): void {
    this.navbar_one = document.querySelector(".navbar-one");
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

  isNotSignIn() {
    // @ts-ignore
    const component = this.route.snapshot.firstChild.component;
    return component !== SignInComponent;

  }

  private handleColorTransparancy() {
    console.log(this.navbar_one)
    // @ts-ignore
    const component = this.route.snapshot.firstChild.component;
    if (component === SignInComponent) {
      this.navbar_one?.classList.add("opacity-background");
      this.navbar_one?.classList.remove("visible-background")
    }
    else{
      this.navbar_one?.classList.remove("opacity-background");
      this.navbar_one?.classList.add("visible-background")
    }

  }
}
