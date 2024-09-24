import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivityExport } from '../models/ActivityExport';
import { ActivityResult } from '../models/ActivityResult';
import { CalorieBurnt } from '../models/CalorieBurnt';
import { SearchExercise } from '../models/SearchExercise';

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {

  constructor(private http:HttpClient) { }

  baseApiUrlsearchExercise:string='http://localhost:5249/api/ExternalVendor/Exercise';
  searchExercise(exerciseFormData:SearchExercise):Observable<any>{
    return this.http.post<any>(this.baseApiUrlsearchExercise,exerciseFormData);
  }


  baseApiUrlCaloriesBurnt:string='http://localhost:5249/api/ExternalVendor/CaloriesBurned';
  caloriesBurnt(exerciseFormActivity:CalorieBurnt):Observable<any>{
    return this.http.post<any>(this.baseApiUrlCaloriesBurnt,exerciseFormActivity);
  }

  baseApiUrlActivityExport:string='http://localhost:5249/api/ExternalVendor/StoreCalories';
  exportActivity(Activityexport:ActivityExport):Observable<any>{
    return this.http.post<any>(this.baseApiUrlActivityExport,Activityexport);
  }

  
}
