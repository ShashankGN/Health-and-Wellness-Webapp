import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from '../models/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  baseApiUrl:string='http://localhost:5172/api/Authentication/register';
  constructor(private http:HttpClient) { }

  addUser(signUpData:Register):Observable<any>{
    return this.http.post<any>(this.baseApiUrl,signUpData);
  }
}
