import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import {RegisterRequest} from "../model/autentification/register/RegisterRequest";
import {RegisterResponse} from "../model/autentification/register/RegisterResponse";
import {SignInRequest} from "../model/autentification/signIn/SignInRequest";
import {SignInResponse} from "../model/autentification/signIn/SignInResponse";

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class AutentificationService{
  private aplUrl = 'http://localhost:5000/authentication/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private httpClient:HttpClient) { }

  registerUser(registerRequest: RegisterRequest): Observable<RegisterResponse>{
    const url = `${this.aplUrl}register`
    return this.httpClient.post<RegisterResponse>(url,registerRequest,{headers: this.headers});
  }
  signInUser(signInrequest: SignInRequest): Observable<any>{
    const url = `${this.aplUrl}signIn`
    return this.httpClient.post<any>(url,signInrequest,{headers: this.headers});
  }

  getAllUsers(): Observable<any>{
    const url = `${this.aplUrl}users`
    return this.httpClient.get<any>(url);
  }
}
