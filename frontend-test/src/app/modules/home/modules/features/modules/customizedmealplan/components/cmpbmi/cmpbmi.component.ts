import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../../../../../../services/auth.service';
import { BmiRecipe } from '../../models/bmiRecipe';
import { BmiRecipeResult } from '../../models/bmiRecipeResult';
import { CmpService } from '../../services/cmp.service';

@Component({
  selector: 'app-cmpbmi',
  templateUrl: './cmpbmi.component.html',
  styleUrl: './cmpbmi.component.css'
})
export class CmpbmiComponent {

  

  showRequest=true;
  showResponse=false;
  name: string | null = null;
  id: string | null = null;
  age: number | null = null;
  gender: string | null = null;

  recipeForm: FormGroup;
  activityLevels = ['Sedentary', 'Lightly active', 'Moderately active', 'Very active', 'Extra active'];

  

  constructor(private authservice:AuthService,private fb: FormBuilder,private cmpservice:CmpService){
    this.recipeForm = this.fb.group({
      name: [{ value:'', disabled: true }, Validators.required],
      age: [{ value: '', disabled: true }, Validators.required],
      gender: [{ value:'', disabled: true }, Validators.required],
      height: ['', Validators.required],
      weight: ['', Validators.required],
      activityLevel: ['', Validators.required],
      number:['',Validators.required]
    });
    
  }

  ngOnInit(): void {
    const claims = this.authservice.getClaims();
    if (claims) {
      // this.name = claims.name;
      // this.id = claims.id;
      // this.age = claims.age;
      // this.gender = claims.gender;
      this.name = claims.fullname; // Use 'fullname' from claims
      this.id = claims.id;
      this.age = parseInt(claims.age, 10); // Convert age from string to number
      this.gender = claims.sex;
    }

    this.recipeForm.patchValue({
      name: this.name,
      age: this.age,
      gender: this.gender
    });


  
    console.log(claims);
  }

  recipeFormData:BmiRecipe={
    activeness:'',
    number:null!,
    height:null!,
    weight:null!
  }


  recipes:BmiRecipeResult[]=[]
  


  onSubmit() {
    this.showRequest=false;
    this.recipeFormData.activeness=this.recipeForm.get("activityLevel")?.value||null;
    this.recipeFormData.height=this.recipeForm.get("height")?.value||null;
    this.recipeFormData.weight=this.recipeForm.get("weight")?.value||null;
    this.recipeFormData.number=this.recipeForm.get("number")?.value||null;

    this.cmpservice.mealOnBmi(this.recipeFormData).subscribe({
      next:(data:any)=>{
        this.recipes=[]
        for (let index = 0; index < data.length; index++) {
          this.recipes.push(data[index]);
          
        }

        console.log(data);
        console.log(this.recipes)
        this.showResponse=true;
      },
      error:(error)=>{
        console.log("in error");
        console.log(error);
      },
      complete:()=>{
        console.log("Data successfully fetched!");
      }
    })




    if (this.recipeForm.valid) {
      console.log(this.recipeForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

  showRequestButton(){
    this.showRequest=true;
    this.showResponse=false;
  }
  

  

  
}
