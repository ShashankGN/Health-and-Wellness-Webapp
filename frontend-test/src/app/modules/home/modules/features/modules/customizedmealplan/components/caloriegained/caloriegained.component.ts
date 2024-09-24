import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CalorieGained } from '../../models/CalorieGained';
import { FoodExport } from '../../models/FoodExport';
import { CmpService } from '../../services/cmp.service';

@Component({
  selector: 'app-caloriegained',
  templateUrl: './caloriegained.component.html',
  styleUrl: './caloriegained.component.css'
})
export class CaloriegainedComponent {
  showRequest = true;
  showResponse = false;
  showList=false;
  calorieGainedForm: FormGroup;
  calorieGainedFormData:CalorieGained={
    ingredient:''
  }

  calorieGainedResult!:number;
  foodName: string = '';

  constructor(private fb: FormBuilder,private router:Router,private cmpservice:CmpService) {
    this.calorieGainedForm = this.fb.group({
      ingredient: ['', Validators.required]
    });
  }


  ngOnInit(): void {
    // Initialization if needed
   
  }


  

  
  

  onSubmit(): void {
    this.calorieGainedFormData.ingredient=this.calorieGainedForm.get('ingredient')?.value||null;
    this.cmpservice.calorieGained(this.calorieGainedFormData).subscribe({
      next:(data:any)=>{
        this.calorieGainedForm!=null;
        this.calorieGainedResult=data;
        // console.log(data);

      },
      error:(error)=>{
        console.log("error in",error);
      },
      complete:()=>{
        console.log("Data successfully fetched!");
        this.showRequest = false;
        this.showResponse = true;
      }
    })
    
  }

  exportdata:FoodExport={
    FoodItems:[],
    TargetCalories:null!
  }

  AddtoList(){
    const obj={
      Name:this.foodName,
      GainedCalories:this.calorieGainedResult
    }
    this.exportdata.FoodItems.push(obj);
    if(this.exportdata.FoodItems.length!==0){
      this.showList=true;
    }
    else{
      this.showList=false;
    }

    const targetCaloriesString = localStorage.getItem('targetgainCalories');
    this.exportdata.TargetCalories= targetCaloriesString ? Number(targetCaloriesString) : 0;
    console.log(obj);
    console.log(this.exportdata);
  }


  showRequestButton(): void {
    this.calorieGainedForm.reset();
    this.showRequest = true;
    this.showResponse = false;
    this.foodName = '';
  }

  exportData(){
    this.cmpservice.exportFood(this.exportdata).subscribe({
      next:(data:any)=>{
        this.exportdata.FoodItems=[];
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
        
        console.log(data);
      },
      error:(error)=>{
        console.log("error in",error);
      },
      complete:()=>{
        localStorage.removeItem("dashgain");
        console.log("Data fetched Successfully!");
      }
    })
  }

}
