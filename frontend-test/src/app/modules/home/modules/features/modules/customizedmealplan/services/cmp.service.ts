import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BmiRecipe } from '../models/bmiRecipe';
import { CalorieGained } from '../models/CalorieGained';
import { FoodExport } from '../models/FoodExport';
import { SearchRecipe } from '../models/searchRecipe';
import { TargetCalorieMeal } from '../models/targetCalorieMeal';

@Injectable({
  providedIn: 'root'
})
export class CmpService {

  constructor(private http:HttpClient) { }

  baseApiUrlsearchRecipe:string='http://localhost:5249/api/ExternalVendor/SearchRecipe';
  searchRecipe(recipeFormData:SearchRecipe):Observable<any>{
    return this.http.post<any>(this.baseApiUrlsearchRecipe,recipeFormData);
  }

  baseApiUrlSearchDayMealTargetCalorie:string='http://localhost:5249/api/ExternalVendor/RecipeDayByTargetCalorie';
  mealPerDay(recipeFormData:TargetCalorieMeal):Observable<any>{
    return this.http.post<any>(this.baseApiUrlSearchDayMealTargetCalorie,recipeFormData);
  }

  baseApiUrlSearchWeekMealTargetCalorie:string='http://localhost:5249/api/ExternalVendor/RecipeWeekByTargetCalorie';
  mealPerWeek(recipeFormData:TargetCalorieMeal):Observable<any>{
    return this.http.post<any>(this.baseApiUrlSearchWeekMealTargetCalorie,recipeFormData);
  }

  baseApiUrlBmiSearch:string='http://localhost:5249/api/ExternalVendor/RecipeByNutrients';
  mealOnBmi(recipeFormData:BmiRecipe):Observable<any>{
    return this.http.post<any>(this.baseApiUrlBmiSearch,recipeFormData);
  }

  baseApiUrlCalorieGained:string='http://localhost:5249/api/ExternalVendor/CaloriesGained';
  calorieGained(calorieGainedFormData:CalorieGained):Observable<any>{
    return this.http.post<any>(this.baseApiUrlCalorieGained,calorieGainedFormData);
  }

  baseApiUrlFoodExport:string='http://localhost:5249/api/ExternalVendor/StoreCaloriesGained';
  exportFood(Foodexport:FoodExport):Observable<any>{
    return this.http.post<any>(this.baseApiUrlFoodExport,Foodexport);
  }

  
}
