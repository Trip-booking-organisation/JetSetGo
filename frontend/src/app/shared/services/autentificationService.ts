import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import {RegisterRequest} from "../../autentification/model/register/RegisterRequest";
import {RegisterResponse} from "../../autentification/model/register/RegisterResponse";
import {SignInRequest} from "../../autentification/model/signIn/SignInRequest";
import {environment} from "../../../environments/environment";


@Injectable({
  providedIn: 'root'
})
export class AutentificationService {
  private aplUrl = `${environment.baseUrl}/authentication`
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private httpClient: HttpClient) {
  }

  registerUser(registerRequest: RegisterRequest): Observable<RegisterResponse> {
    const url = `${this.aplUrl}/register`
    return this.httpClient.post<RegisterResponse>(url, registerRequest, {headers: this.headers});
  }

  signInUser(signInRequest: SignInRequest): Observable<any> {
    const url = `${this.aplUrl}/signIn`
    return this.httpClient.post<any>(url, signInRequest, {headers: this.headers});
  }

  getAllUsers(): Observable<any> {
    const url = `${this.aplUrl}users`
    return this.httpClient.get<any>(url);
  }
}
