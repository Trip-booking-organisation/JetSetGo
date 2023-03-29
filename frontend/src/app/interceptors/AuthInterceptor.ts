import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {TokenStorageService} from "../services/tokenStorage.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
  constructor(private tokenStorageService: TokenStorageService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.tokenStorageService.getToken()
    if(token){
      const clonedReq =req.clone({
        headers: req.headers.set("Authorization",
          "Bearer " + token )
      });
     return next.handle(clonedReq);
   }
    else {
      return next.handle(req)
    }

  }

}
