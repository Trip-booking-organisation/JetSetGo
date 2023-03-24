import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import {TokenStorageService} from "../../services/tokenStorage.service";

@Injectable({
  providedIn: 'root'
})
export class IsAuthentificatedGuard implements CanActivate {
  constructor(private tokenStorageService: TokenStorageService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.tokenStorageService.isLoggedIn();
  }

}
