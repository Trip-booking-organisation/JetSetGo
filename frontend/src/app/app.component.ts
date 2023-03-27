import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {SignInComponent} from "./autentification/view/sign-in/sign-in.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  navBarVisibility = true;
  @Output() onPaintNavBar = new EventEmitter<boolean>();

  constructor(private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.toggleNavBar()
      }
    })
  }

  toggleNavBar() {
    // @ts-ignore
    const component = this.route.snapshot.firstChild.component;
    if (component === SignInComponent) {
      this.navBarVisibility = false;
      this.onPaintNavBar.emit(false)
    } else {
      this.navBarVisibility = true;
      this.onPaintNavBar.emit(true)
    }
  }


}
