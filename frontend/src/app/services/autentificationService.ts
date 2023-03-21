import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import {RegisterRequest} from "../model/autentification/RegisterRequest";
import {RegisterResponse} from "../model/autentification/RegisterResponse";

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class AutentificationService{
  private aplUrl = 'http://localhost:5000/authentification/'
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private httpClient:HttpClient) { }

  registerUser(registerRequest: RegisterRequest): Observable<RegisterResponse>{
    const url = `${this.aplUrl}register`
    return this.httpClient.post<RegisterResponse>(url,registerRequest,{headers: this.headers});
  }
}
