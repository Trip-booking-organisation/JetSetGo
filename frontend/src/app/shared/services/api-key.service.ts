import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {RegisterResponse} from "../../autentification/model/register/RegisterResponse";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ApiKeyRequest} from "../model/ApiKeyRequest";
import {MatDialogRef} from "@angular/material/dialog";

@Injectable({
  providedIn: 'root'
})
export class ApiKeyService {
  private baseUrl = `${environment.baseUrl}`
  headers: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});
  constructor(private httpClient: HttpClient) { }
  generateApiKey(request: ApiKeyRequest): Observable<any> {
    const url = `${this.baseUrl}/api/api-keys`
    return this.httpClient.post<any>(url, request, {headers: this.headers});
  }

}
