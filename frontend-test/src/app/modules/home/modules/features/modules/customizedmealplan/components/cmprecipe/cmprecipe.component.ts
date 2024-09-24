import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchRecipe } from '../../models/searchRecipe';
import { FetchedResult } from '../../models/searchRecipeResult';
import { CmpService } from '../../services/cmp.service';

@Component({
  selector: 'app-cmprecipe',
  templateUrl: './cmprecipe.component.html',
  styleUrl: './cmprecipe.component.css'
})
export class CmprecipeComponent {
  recipeForm: FormGroup;
  showAdvancedFilters = false;
  dietOptions = [
    'Gluten Free', 'Ketogenic', 'Vegetarian', 'Lacto-Vegetarian', 
    'Ovo-Vegetarian', 'Vegan', 'Pescetarian', 'Paleo', 'Primal', 
    'Low FODMAP', 'Whole30'
  ];
  typeOptions = [
    'Main Course', 'Side Dish', 'Dessert', 'Appetizer', 'Salad', 
    'Bread', 'Breakfast', 'Soup', 'Beverage', 'Sauce', 
    'Marinade', 'Fingerfood', 'Snack', 'Drink'
  ];
  cuisineInvalid = false;
  maxCarbsLessThanMinCarbs = false;
  maxCaloriesLessThanMinCalories = false;
  maxFatLessThanMinFat = false;
  showResponse=false;
  showRequest=true;

  constructor(private fb: FormBuilder,private cmpservice:CmpService) {
    this.recipeForm = this.fb.group({
      query: ['', Validators.required],
      number: ['', [Validators.required, Validators.min(1)]],
      cuisine: [''],
      excludeCuisine: [''],
      diet: [''],
      type: [''],
      minCarbs: [''],
      maxCarbs: [''],
      minCalories: [''],
      maxCalories: [''],
      minFat: [''],
      maxFat: ['']
    });
  }

  isRequired(controlName: string): boolean {
    const control = this.recipeForm.get(controlName);
    return control?.hasValidator(Validators.required) ?? false;
  }

  ngOnInit() {
    this.recipeForm.valueChanges.subscribe(() => {
    this.validateCuisine();
    this.validateCarbs();
    this.validateCalories();
    this.validateFat();
  });
  }

  

  recipeFormData:SearchRecipe={
    Query:'',
    Cuisine:'',
    ExcludeCuisine:'',
    Diet:'',
    Type:'',
    Sort:'',
    MinCarbs:null!,
    MaxCarbs:null!,
    MaxCalories:null!,
    MinCalories:null!,
    MinFat:null!,
    MaxFat:null!,
    Number:null!
  }

  toggleAdvancedFilters(): void {
    this.showAdvancedFilters = !this.showAdvancedFilters;
  }

  validateCuisine() {
    const cuisine = this.recipeForm.get('cuisine')?.value;
    const excludeCuisine = this.recipeForm.get('excludeCuisine')?.value;
    this.cuisineInvalid = cuisine && excludeCuisine && cuisine.toLowerCase() === excludeCuisine.toLowerCase();
  }

  validateCarbs() {
    const minCarbs = this.recipeForm.get('minCarbs')?.value;
    const maxCarbs = this.recipeForm.get('maxCarbs')?.value;
    this.maxCarbsLessThanMinCarbs = minCarbs != null && maxCarbs != null && maxCarbs < minCarbs;
  }

  validateCalories() {
    const minCalories = this.recipeForm.get('minCalories')?.value;
    const maxCalories = this.recipeForm.get('maxCalories')?.value;
    this.maxCaloriesLessThanMinCalories = minCalories != null && maxCalories != null && maxCalories < minCalories;
  }

  validateFat() {
    const minFat = this.recipeForm.get('minFat')?.value;
    const maxFat = this.recipeForm.get('maxFat')?.value;
    this.maxFatLessThanMinFat = minFat != null && maxFat != null && maxFat < minFat;
  }

  
  recipes:FetchedResult[]=[];

  onSubmit() {
    this.showRequest=false;
    this.recipeFormData.Query=this.recipeForm.get("query")?.value||null;
    this.recipeFormData.Number=this.recipeForm.get("number")?.value||null;
    this.recipeFormData.Diet=this.recipeForm.get("diet")?.value||null;
    this.recipeFormData.Cuisine=this.recipeForm.get("cuisine")?.value||null;
    this.recipeFormData.ExcludeCuisine=this.recipeForm.get("excludeCuisine")?.value||null;
    this.recipeFormData.Type=this.recipeForm.get("type")?.value||null;
    this.recipeFormData.MinCarbs=this.recipeForm.get("minCarbs")?.value||null;
    this.recipeFormData.MaxCarbs=this.recipeForm.get("maxCarbs")?.value||null;
    this.recipeFormData.MaxCalories=this.recipeForm.get("maxCalories")?.value||null;
    this.recipeFormData.MinCalories=this.recipeForm.get("minCalories")?.value||null;
    this.recipeFormData.MinFat=this.recipeForm.get("minFat")?.value||null;
    this.recipeFormData.MaxFat=this.recipeForm.get("maxFat")?.value||null;
    

    this.cmpservice.searchRecipe(this.recipeFormData).subscribe({
      next:(data:any)=>{
        
        this.recipes=[];
        for (let index = 0; index < data.results.length; index++) {
          this.recipes.push(data.results[index]);
        }
        console.log(this.recipes);
        
        
        console.log(data);
        this.showResponse=true;

      },
      error:(error)=>{
        console.log("in error");
        console.log(error);
      },
      complete:()=>{
        console.log("Successfully fetched!");
      }

    })


    // if (this.recipeForm.valid) {
    //   console.log(this.recipeForm.value);
    // } else {
    //   console.log("Form is invalid");
    // }
  }

  showRequestButton(){
    this.showRequest=true;
    this.showResponse=false;
  }

}
