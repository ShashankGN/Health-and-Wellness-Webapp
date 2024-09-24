import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TargetCalorieMeal } from '../../models/targetCalorieMeal';
import { MealDay, NutrientsDay } from '../../models/targetCalorieMealsDayResult';
import { targetCalorieMealWeekResult } from '../../models/targetCalorieMealsWeekResult';
import { CmpService } from '../../services/cmp.service';

@Component({
  selector: 'app-cmptargetcalorie',
  templateUrl: './cmptargetcalorie.component.html',
  styleUrl: './cmptargetcalorie.component.css'
})
export class CmptargetcalorieComponent {

  recipeForm: FormGroup;
  timeFrameOptions = ['Day', 'Week'];
  dietOptions = [
    'Gluten Free', 'Ketogenic', 'Vegetarian', 'Lacto-Vegetarian',
    'Ovo-Vegetarian', 'Vegan', 'Pescetarian', 'Paleo', 'Primal',
    'Low FODMAP', 'Whole30'
  ];
  targetCaloriesInvalid = false;
  showResponse = false;
  showRequest = true;

  constructor(private fb: FormBuilder, private cmpservice: CmpService) {
    this.recipeForm = this.fb.group({
      timeFrame: ['', Validators.required],
      targetCalories: ['', [Validators.required, Validators.min(1)]],
      diet: [''],
      exclude: ['']
    });
  }

  ngOnInit() {
    this.recipeForm.valueChanges.subscribe(() => {
      this.validateTargetCalories();
    });
  }

  validateTargetCalories() {
    const timeFrame = this.recipeForm.get('timeFrame')?.value;
    const targetCalories = this.recipeForm.get('targetCalories')?.value;

    if (timeFrame === 'Day' && targetCalories > 2000) {
      this.targetCaloriesInvalid = true;
    } else if (timeFrame === 'Week' && targetCalories > 21000) {
      this.targetCaloriesInvalid = true;
    } else {
      this.targetCaloriesInvalid = false;
    }
  }

  recipeFormData: TargetCalorieMeal = {
    TimeFrame: '',
    TargetCalories: null!,
    Diet: '',
    Exclude: ''
  }

  recipesDay: MealDay[] = []
  imageUrl:string[]=[];
  nutrientsDay!: NutrientsDay;
  recipesWeek: targetCalorieMealWeekResult[] = []
  mealTimeFrameDay:boolean=false;
  mealTimeFrameWeek:boolean=false;
  days: string[] = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
  onSubmit() {
    this.showRequest = false;
    this.recipeFormData.TimeFrame = this.recipeForm.get("timeFrame")?.value || null;
    this.recipeFormData.TargetCalories = this.recipeForm.get("targetCalories")?.value || null;
    this.recipeFormData.Diet = this.recipeForm.get("diet")?.value || null;
    this.recipeFormData.Exclude = this.recipeForm.get("exclude")?.value || null;


    const schedule = this.recipeForm.get("timeFrame")?.value || null;
    console.log(schedule);
    if (schedule == "Day") {
      this.cmpservice.mealPerDay(this.recipeFormData).subscribe({
        next: (data: any) => {
          console.log(data);
          this.recipesDay = []
          this.imageUrl=[]
          for (let index = 0; index < data.meals.length; index++) {
            // console.log(data.meals);

            //  const obj:MealDay={
            //   id:data.meals[index].id,
            //   imageType:data.meals[index].imageType,
            //   title:data.meals[index].title,
            //   readyInMinutes:data.meals[index].readyInMinutes,
            //   servings:data.meals[index].servings,
            //   sourceUrl:data.meals[index].sourceUrl,
            //   imageUrl:`https://img.spoonacular.com/recipes/${data.meals[index].id}-556x370.jpg`

            // }
            this.recipesDay.push(data.meals[index]);
            
            this.imageUrl.push(`https://img.spoonacular.com/recipes/${data.meals[index].id}-556x370.jpg`);
          }
          let i=0;
          this.recipesDay.forEach(element => {
            element.imageUrl=this.imageUrl[i++];
          });
          this.nutrientsDay = data.nutrients;
          console.log(this.recipesDay);
          console.log(this.nutrientsDay);
          this.showResponse = true
          this.mealTimeFrameDay=true
        },
        error: (error) => {
          console.log("in error");
          console.log(error);
        },
        complete: () => {
          console.log("Data fetched successfully!");
        }

      })
    }
    else if (schedule == "Week") {
      this.cmpservice.mealPerWeek(this.recipeFormData).subscribe({
        next: (data: any) => {
          console.log(data);
          this.mealTimeFrameWeek=true;
          this.showResponse = true
          this.recipesWeek = [];
          

          // Map response data to recipesWeek
          for (let day of this.days) {
            // Convert day to lowercase to match the response keys
            let lowerCaseDay = day.toLowerCase();

            if (data.week[lowerCaseDay]) {
              let dayData = data.week[lowerCaseDay];

              this.recipesWeek.push({
                day: day,
                meal: dayData.meals,
                nutrients: dayData.nutrients,
                
              });
            }
          }
          let i=0;
          this.recipesWeek.forEach(element => {
            for (let index = 0; index < 3; index++) {
              element.meal[index].imageUrl=`https://img.spoonacular.com/recipes/${element.meal[index].id}-556x370.jpg`;
            }
          });
          console.log(this.recipesWeek);
          
        },
        error: (error) => {
          console.log("in error");
          console.log(error);
        },
        complete: () => {
          console.log("Data fetched successfully!");
        }

      })
    }



    if (this.recipeForm.valid && !this.targetCaloriesInvalid) {
      console.log(this.recipeForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

  showRequestButton() {
    this.showRequest = true;
    this.showResponse = false;
    this.mealTimeFrameDay=false;
  this.mealTimeFrameWeek=false;
  }
}
