import { AfterViewInit, Component, OnChanges, OnInit } from '@angular/core';
import { HomeService } from '../../services/home.service';

interface Activity {
  name: string;
  burntCalories: number;
  hoursSpent: number;
}

interface FoodItems {
  name: string;
  gainedCalories: number;

}
@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrl: './start.component.css'
})
export class StartComponent implements OnInit {


  constructor(private homeservice:HomeService){}
  burntCalorieData:any;
  gainedCalorieData:any;
  showBurntCompletion=false;
  gained=false;
  message!:string;
  ngOnInit(): void {

    this.homeservice.getGainedCalorie().subscribe({
      next:(data:any)=>{
        this.gainedCalorieData=data;
        if(data===null){
          localStorage.setItem('dashgain',"empty");
        }
        this.updateCalorieGainSection();
        
        console.log(this.gainedCalorieData);
      },
      error:(error)=>{
        console.log("in error",error);
      },
      complete:()=>{
        this.message=this.gainedCalorieData.message;

        console.log(this.gainedCalorieData.message);
        console.log("Data fetched successfully!");
      }
    })


    this.homeservice.getBurntCalorie().subscribe({
      next:(data:any)=>{
        this.burntCalorieData=data;
        if(data===null)
        localStorage.setItem('dash',"empty");
        // console.log(this.burntCalorieData);
        this.updateCalorieBurnSection();
        
      },
      error:(error)=>{
        console.log("in error",error);
      },
      complete:()=>{
        console.log("Data fetched successfully!");
      }
    })

  }

  

  ngAfterViewInit(){
    
    
    
  }
  
  private updateCalorieBurnSection(){
    const radius = 80;
    const circumference = 2 * Math.PI * radius;
    const percentageOffset = ((100 - this.burntCalorieData.percentage) / 100) * circumference;
    const circle = document.querySelector('.progress-ring__circle-burn') as SVGCircleElement;
    const percentageText = document.getElementById('percentageValue') as HTMLElement;
    const activitiesList = document.getElementById('activitiesList') as HTMLElement;

    setTimeout(() => {
      if (circle) {
        circle.style.strokeDashoffset = `${percentageOffset}`;
      }
      if (percentageText) {
        percentageText.textContent = `${this.burntCalorieData.percentage.toFixed(2)}%`;
      }
    }, 500);

    if (activitiesList) {
      this.burntCalorieData.activities.forEach((activity:Activity) => {
        const li = document.createElement('li');
        li.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-center');
        li.innerHTML = `<strong>${activity.name}</strong><span>${activity.burntCalories} Calories, ${activity.hoursSpent/60} Hours</span>`;
        activitiesList.appendChild(li);
      });
    }
    if(this.burntCalorieData.percentage===100){
      this.showBurntCompletion=true;
    }
  }

  private updateCalorieGainSection(){
    
    const radius = 80;
    const circumference = 2 * Math.PI * radius;
    const percentageOffset = ((100 - this.gainedCalorieData.percentage) / 100) * circumference;
    const circle = document.querySelector('.progress-ring__circle-gain') as SVGCircleElement;
    const percentageText = document.getElementById('calorieGainPercentageValue') as HTMLElement;
    const activitiesList = document.getElementById('calorieGainActivitiesList') as HTMLElement;

    setTimeout(() => {
      if (circle) {
        circle.style.strokeDashoffset = `${percentageOffset}`;
      }
      if (percentageText) {
        percentageText.textContent = `${this.gainedCalorieData.percentage.toFixed(2)}%`;
        // percentageText.textContent = "50%";
      }
    }, 500);

    if (activitiesList) {
      this.gainedCalorieData.foods.forEach((food:FoodItems) => {
        const li = document.createElement('li');
        li.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-center');
        li.innerHTML = `<strong>${food.name}</strong><span>${food.gainedCalories} Calories</span>`;
        activitiesList.appendChild(li);
      });
    }

    if(this.gainedCalorieData.percentage===100){
      this.gained=true;
    }
    
  }

}
