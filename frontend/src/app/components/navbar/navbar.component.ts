import {Component, EventEmitter, HostListener, Input, OnInit, Output} from '@angular/core';
import {navDataPassenger} from "./data-access/passenger-nav-data";
import {ActivatedRoute, Router} from "@angular/router";
import {TokenStorageService} from "../../shared/services/tokenStorage.service";
import {AutentificationService} from "../../shared/services/autentificationService";
import {noRegisterUserNavData} from "./data-access/no-register-user-nav-data";
import {User} from "../../shared/model/User";
import {adminNavData} from "./data-access/admin-nav-data";
import {ToastrService} from "ngx-toastr";
import {ConfirmDialogData, ModalDialogComponent} from "../modal-dialog/modal-dialog.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  activeClass: string = 'navbar-menu';
  addBackground: string = 'navbar-two';
  isCollapsed: boolean = false
  navDataPassenger = navDataPassenger;
  navDataNoRegister = noRegisterUserNavData;
  navDataAdmin = adminNavData;
  userToken: User;
  isLogged!: boolean;
  @Input() second_nav_visibility = true;
  @Output() on_register_route: EventEmitter<boolean> = new EventEmitter();


  constructor(private router: Router, private route: ActivatedRoute,
              private tokenStorage: TokenStorageService,
              private authenticationService: AutentificationService, private toast: ToastrService
    , private dialog: MatDialog) {
    this.userToken = this.tokenStorage.getUser()
    this.tokenStorage.isAuthenticated.subscribe(
      (authenticated: boolean) => {
        this.userToken = this.tokenStorage.getUser()
        this.isLogged = authenticated;
      }
    );
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

  navigate(routerLink: string) {
    this.activeClass = 'navbar-menu'
    this.router.navigate([routerLink]).then()

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
    const data: ConfirmDialogData = {
      title: 'Are you sure?',
      message: 'You will be log out now',
    };

    const dialogRef = this.dialog.open(ModalDialogComponent, {
      width: '500px',
      data: data,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.tokenStorage.signOut();
        this.router.navigate(['']).then(_ => {
          this.toast.success("You are successfully logged out", "Log out")
        })
      }
    });

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
