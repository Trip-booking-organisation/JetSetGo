import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable, tap} from 'rxjs';
import {TokenStorageService} from "../../services/tokenStorage.service";

@Injectable({
  providedIn: 'root'
})
export class IsAuthentificatedGuard implements CanActivate {
  constructor(private tokenStorageService: TokenStorageService, private router:Router ){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    var isLoggedIn = this.tokenStorageService.isLoggedIn();
    if(!isLoggedIn){
      this.router.navigate(['/error'], { queryParams: { errorExplanation: "Please log in." } });
    }
    return true;
  }

}
