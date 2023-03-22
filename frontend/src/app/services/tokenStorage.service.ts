import {Injectable} from "@angular/core";
import {User} from "../model/ApplicationUser/User";
const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';


@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor() { }
  public saveToken(token:string){
    console.log("token: ",token)
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY,token);
  }
  public isLoggedIn(): boolean{
    return !! window.sessionStorage.getItem(TOKEN_KEY);
  }
  public saveUser(token : string):void{
    let user:string = atob(token.split('.')[1]);
    let userObject = JSON.parse(user)
    let userTk:User = new User(userObject.id,userObject.role,userObject.firstLogIn);
    console.log(userObject)
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(userTk));
  }
  public getUser(): User {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      console.log(user)
      return JSON.parse(user);
    }
    return new User("","",false);
  }

}
