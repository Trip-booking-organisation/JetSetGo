import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {TokenStorageService} from "../../shared/services/tokenStorage.service";

@Injectable({
  providedIn: 'root'
})
export class HasRoleGuard implements CanActivate {
  constructor(private tokenStorageService: TokenStorageService, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // return this.tokenStorageService.getUser().role.includes(route.data['role']);
    const hasRole = route.data['role'].includes(this.tokenStorageService.getUser().role);
    if (!hasRole) {
      this.router.navigate(['/error'], {queryParams: {errorExplanation: "The page you are trying to access is not available to your account level. Please contact support if you need assistance."}});
    }
    return true;
  }

}
