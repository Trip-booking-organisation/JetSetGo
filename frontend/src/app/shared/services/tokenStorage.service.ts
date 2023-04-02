import {Injectable} from "@angular/core";
import {User} from "../model/User";
import {BehaviorSubject} from "rxjs";

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';


@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  private isAuthenticated$ = new BehaviorSubject<boolean>(false);

  get isAuthenticated() {
    return this.isAuthenticated$.asObservable();
  }

  constructor() {
    if (this.isLoggedIn()) {
      this.login()
    }
  }

  public saveToken(token: string) {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
    this.login()
  }

  public signOut(): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.clear();
    this.logout()
  }

  public isLoggedIn(): boolean {
    return !!window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(token: string): void {
    let user: string = atob(token.split('.')[1]);
    let userObject = JSON.parse(user)
    let userTk: User = new User(userObject.sub, userObject.role, userObject.firstLogIn, userObject.given_name,
      userObject.family_name, userObject.email);
    window.sessionStorage.removeItem(USER_KEY);
    console.log(JSON.stringify(userTk))
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(userTk));
    this.login()
  }

  public getUser(): User {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return new User("", "", false, "", ',', '');
  }

  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  private login() {
    this.isAuthenticated$.next(true);
  }

  public logout() {
    this.isAuthenticated$.next(false);
  }
}
