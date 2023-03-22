import {Component, OnInit} from '@angular/core';
import {NavigationEnd,ActivatedRoute, Router} from "@angular/router";
import {SignInComponent} from "./view/autentification/sign-in/sign-in.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  navBarVisibility = true;
  constructor(private router:Router,private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.router.events.subscribe(event=>{
      if(event instanceof NavigationEnd){
        this.toggleNavBar()
      }
    })
  }

  toggleNavBar() {
    // @ts-ignore
    const component = this.route.snapshot.firstChild.component;
    if (component === SignInComponent) {
      this.navBarVisibility=false;
    }
    else {
      this.navBarVisibility=true;

    }
  }


}
