import {Component, EventEmitter, HostListener, Input, OnInit, Output} from '@angular/core';
import {navData} from "./passenger-nav-data";
import {ActivatedRoute, Router} from "@angular/router";
import {TokenStorageService} from "../../shared/services/tokenStorage.service";
import {AutentificationService} from "../../shared/services/autentificationService";

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
  @Input() second_nav_visibility = true;
  @Output() on_register_route: EventEmitter<boolean> = new EventEmitter();


  constructor(private router: Router, private route: ActivatedRoute,
              private tokenStorage: TokenStorageService,
              private authenticationService: AutentificationService) {

  }

  ngOnInit(): void {

  }

  showNavBar() {
    this.activeClass = this.isCollapsed ? 'navbar-menu' : 'navbar-menu show-nav';
    this.isCollapsed = !this.isCollapsed
  }

  @HostListener('window:scroll', ['$event'])
  addBg() {
    this.addBackground = window.scrollY >= 200
      ? 'navbar-two'
      : 'navbar-two nav-bg';
  }

  removeNavBar() {
    this.activeClass = 'navbar-menu'
  }

  goToSignIn() {
    this.router.navigate(['signIn']).then();
  }


  goToRegister() {
    this.router.navigate(['signIn'], {queryParams: {isRegistration: true}}).then();
    console.log(this.tokenStorage.getUser())
  }

  checkIfSignedIn() {
    let token = this.tokenStorage.getToken();
    return !!token;

  }

  LogOut() {
    this.tokenStorage.signOut();
    this.router.navigate(['']).then()
  }

  checkAuthorisation() {
    this.authenticationService.getAllUsers().subscribe({
      next: res => {
        console.log(res)
      }
    })
  }

  navigateHome() {
    this.router.navigate(['']).then();
  }
}
