import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http:HttpClient) { }

  baseApiUrlGetBurntCalorieData:string='http://localhost:5249/api/ExternalVendor/GetRecord';
  getBurntCalorie():Observable<any>{
    return this.http.get<any>(this.baseApiUrlGetBurntCalorieData);
  }


  baseApiUrlGetGainedCalorieData:string='http://localhost:5249/api/ExternalVendor/StoredGainCalories';
  getGainedCalorie():Observable<any>{
    return this.http.get<any>(this.baseApiUrlGetGainedCalorieData);
  }
}
