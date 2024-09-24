import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Login } from '../appcomponents/models/login';
import { Register } from '../appcomponents/models/register';
import { Updateuser } from '../modules/home/models/Updateuser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  
  constructor(private http:HttpClient,private router:Router) { }

  tokenPresentOrNot(){
    // console.log(localStorage.getItem("jwt"));
    return localStorage.getItem("jwt");
  }

  baseApiUrlgetToken:string='http://localhost:5172/api/Authentication/login';
  getToken(loginData:Login):Observable<any>{
    return this.http.post<any>(this.baseApiUrlgetToken,loginData);
  }

  baseApiUrlsignUpData:string='http://localhost:5172/api/Authentication/register';

  addUser(signUpData:Register):Observable<any>{
    return this.http.post<any>(this.baseApiUrlsignUpData,signUpData);
  }

  isLoggedIn():boolean{
    // console.log(this.tokenPresentOrNot());
    return  this.tokenPresentOrNot()!==null;
  }

  logout(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("lastlogindate");
    localStorage.removeItem("targetCalories");
    localStorage.removeItem("targetgainCalories");
    localStorage.removeItem("dash");
    localStorage.removeItem("dashgain");
    this.router.navigate(['']);
    
  }

  getClaims() {
    const token = this.tokenPresentOrNot();
    if (token) {
      return this.decodeToken(token);
    }
    return null;
  }

  private decodeToken(token: string) {
    // JWTs are typically in the format: header.payload.signature
    const payload = token.split('.')[1]; // Get the payload part
    if (payload) {
      const decoded = atob(payload); // Decode from base64
      return JSON.parse(decoded); // Parse JSON
    }
    return null;
  }

  baseApiUrlDeleteUser:string='http://localhost:5172/api/Authentication/delete-user/';

  deleteUser(id:string):Observable<any>{
    // console.log(id);
    return this.http.delete<any>(`${this.baseApiUrlDeleteUser}${id}`);
  }


  baseApiUrlUpdateUser:string='http://localhost:5172/api/Authentication/update-user/';

  updateUser(id:string,updateUserFormData:Updateuser):Observable<any>{
    // console.log(id);
    return this.http.put<any>(`${this.baseApiUrlUpdateUser}${id}`,updateUserFormData);
  }



}
