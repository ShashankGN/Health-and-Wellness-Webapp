import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ActivityExport } from '../../models/ActivityExport';
import { ActivityResult } from '../../models/ActivityResult';
import { CalorieBurnt } from '../../models/CalorieBurnt';
import { CalorieBurntResult } from '../../models/CalorieBurntResult';
import { ExerciseService } from '../../services/exercise.service';

@Component({
  selector: 'app-calorieburnt',
  templateUrl: './calorieburnt.component.html',
  styleUrl: './calorieburnt.component.css'
})
export class CalorieburntComponent {
  showRequest = true;
  showResponse = false;
  showList=false;
  exerciseForm: FormGroup;
  showModal = false;
  selectedActivity: CalorieBurntResult | null = null;
  exerciseFormData: CalorieBurnt = {
    activity: ''
  }
  activityResult: CalorieBurntResult[] = []
  

  constructor(private fb: FormBuilder, private exerciseservice: ExerciseService,private router:Router) {
    this.exerciseForm = this.fb.group({
      activity: ['', Validators.required]
    });
  }


  ngOnInit(): void {
    // Initialization if needed
   
  }



  toggleDetails(activityId: number): void {
    this.activityResult.forEach(activity => {
      if (activity.id === activityId) {
        activity.isDetailsVisible = !activity.isDetailsVisible;
      } else {
        activity.isDetailsVisible = false;  // Hide details of other cards
      }
    });
  }

  updateTotalCaloriesBurnt(activity: CalorieBurntResult): void {
    const duration = activity.duration_minutes;
    const caloriesPerHour = activity.calories_per_hour;
    activity.total_calories = (caloriesPerHour / 60) * duration;
  }


  
  

  onSubmit(): void {
    this.exerciseFormData.activity = this.exerciseForm.get('activity')?.value || '';
    this.exerciseservice.caloriesBurnt(this.exerciseFormData).subscribe({
      next: (data: any) => {
        this.activityResult = data.map((item: any, index: number) => ({
          id: index + 1,
          name: item.name,
          calories_per_hour: item.calories_per_hour,
          duration_minutes: item.duration_minutes || 30,  // Default value
          total_calories: item.total_calories || 0,  // Default value
          isDetailsVisible: false
        }));
        console.log(this.activityResult)

      },
      error: (error) => {
        console.error('Error fetching data', error);
      },
      complete: () => {
        console.log('Data successfully fetched!');
        this.showRequest = false;
        this.showResponse = true;
      }
    });
  }

  showRequestButton(): void {
    this.exerciseForm.reset();
    this.showRequest = true;
    this.showResponse = false;
  }

  // ActivityList:ActivityResult[]=[]
  exportdata:ActivityExport={
    Activities:[],
    TargetCalories:null!
  }
  

  AddtoList(id:number) {
    const activity = this.activityResult.find(act => act.id === id);
    if (activity) {
      const obj={
        Name:activity.name,
        BurntCalories:activity.total_calories,
        HoursSpent:activity.duration_minutes
      }
      
      this.exportdata.Activities.push(obj);
      if(this.exportdata.Activities.length!==0){
        this.showList=true;
      }
      else{
        this.showList=false;
      }
    }
    const targetCaloriesString = localStorage.getItem('targetCalories');
    this.exportdata.TargetCalories= targetCaloriesString ? Number(targetCaloriesString) : 0;

    console.log(this.exportdata);
  }

  exportData(){
    this.exerciseservice.exportActivity(this.exportdata).subscribe({
      next:(data:any)=>{
        console.log(data);
      this.exportdata.Activities=[];
      this.router.navigate(["home"]).then(() => {
        // Show SweetAlert2 notification after navigation
        Swal.fire({
          icon: 'success',
          title: `Data Saved Successfully!`,
          text: 'You can now see your progress on the dashboard!',
          timer: 3000,
          timerProgressBar: false,
          showConfirmButton: false,
          customClass: {
            confirmButton: 'custom-confirm-button'
          }
        });
      });
      },
      error:(error)=>{
        console.log("error in",error);
      },
      complete:()=>{
        localStorage.removeItem("dash");
        console.log("data fetched successfully!");
      }

    })
  }










}

