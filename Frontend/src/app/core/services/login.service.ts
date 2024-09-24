import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/Login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseApiUrl:string='http://localhost:5172/api/Authentication/login';
  constructor(private http:HttpClient) { }

  getToken(loginData:Login):Observable<any>{
    return this.http.post<any>(this.baseApiUrl,loginData);
  }
}
