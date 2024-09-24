import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchExercise } from '../../models/SearchExercise';
import { SearchExerciseResult } from '../../models/SearchExerciseResult';
import { ExerciseService } from '../../services/exercise.service';

@Component({
  selector: 'app-customizedexercise',
  templateUrl: './customizedexercise.component.html',
  styleUrl: './customizedexercise.component.css'
})
export class CustomizedexerciseComponent {
  showRequest=true;
  showResponse=false;

  exerciseForm: FormGroup;
  bodyParts = ['back', 'cardio', 'chest', 'lower arms', 'lower legs','neck','shoulders','upper arms','upper legs','waist'];

  constructor(private fb:FormBuilder,private exerciseService:ExerciseService){
    this.exerciseForm = this.fb.group({
     
      bodypart: ['',Validators.required],
      number:['',Validators.required]
    });
  }

  exerciseFormData:SearchExercise={
    bodypart:'',
    number:null!
  }
  selectedRecipe: any = null;
  openModal(recipe: any) {
    this.selectedRecipe = recipe;
  }

  closeModal() {
    this.selectedRecipe = null;
  }

  

  recipes:SearchExerciseResult[]=[]


  onSubmit(){
    this.showRequest=false;
    this.exerciseFormData.bodypart=this.exerciseForm.get("bodypart")?.value||null;
    this.exerciseFormData.number=this.exerciseForm.get("number")?.value||null;
    this.exerciseService.searchExercise(this.exerciseFormData).subscribe({
      next:(data:any)=>{
        this.recipes=[]
        for (let index = 0; index < data.length; index++) {
          this.recipes.push(data[index]);
          
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
        console.log("Data successfully fetched!")
      }

    })










    if (this.exerciseForm.valid) {
      console.log(this.exerciseForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

showRequestButton(){
  this.showRequest=true;
  this.showResponse=false;
}
  
}
