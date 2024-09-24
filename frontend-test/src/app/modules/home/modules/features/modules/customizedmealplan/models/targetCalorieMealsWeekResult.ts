export type targetCalorieMealWeekResult= {
    day:string;
    meal:Mealweek[];
    nutrients:NutrientsWeek;
    
  }
  
  export type Mealweek={
    id: number;
    imageType: string;
    title: string;
    readyInMinutes: number;
    servings: number;
    sourceUrl: string;
    imageUrl:string;
  }
  
  export type NutrientsWeek ={
    calories: number;
    protein: number;
    fat: number;
    carbohydrates: number;
  }
  