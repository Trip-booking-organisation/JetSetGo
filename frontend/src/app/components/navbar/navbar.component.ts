import {Component, EventEmitter, HostListener, Input, OnInit, Output} from '@angular/core';
import {navData} from "./passenger-nav-data";
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {SignInComponent} from "../../view/autentification/sign-in/sign-in.component";
import {TokenStorageService} from "../../services/tokenStorage.service";
import {AutentificationService} from "../../services/autentificationService";

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
  @Input() second_nav_visibility =true;


  constructor(private router: Router,private route: ActivatedRoute, private tokenStorage:TokenStorageService,
              private authentificatoinService:AutentificationService){

  }
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



  private handleColorTransparancy() {
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

  goToRegister() {
    console.log(this.tokenStorage.getUser())
  }

  checkIfSignedIn() {
    var token = this.tokenStorage.getToken()
    return !!token;

  }

  LogOut() {
    this.tokenStorage.signOut();
    // window.location.reload()
  }

  checkAuthorisation() {
    this.authentificatoinService.getAllUsers().subscribe({
      next: res=>{
        console.log(res)
      }
    })
  }
}
