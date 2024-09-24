import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Register } from '../../../core/models/register';
import { RegisterService } from '../../../core/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  signUpForm:FormGroup
  userFailed:boolean=false
  passwordFailed:boolean=false

  constructor(private fb:FormBuilder,private registerService:RegisterService,private router:Router){
      this.signUpForm = this.fb.group({
        username: ['', [Validators.required]],
        password: ['', [Validators.required,Validators.minLength(8)]],
        email:['',[Validators.required,Validators.email]],
        fullname:['',[Validators.required]],
        age:['',[Validators.required]],
        gender:['',Validators.required]
      });
  }

  signUpData:Register={
    fullName:'',
    userName:'',
    password:'',
    email:'',
    gender:'',
    age:null!
  }
  signUp():void{
    this.signUpData.userName=this.signUpForm.get("username")?.value;
    this.signUpData.fullName=this.signUpForm.get("fullname")?.value;
    this.signUpData.password=this.signUpForm.get("password")?.value;
    this.signUpData.email=this.signUpForm.get("email")?.value;
    this.signUpData.gender=this.signUpForm.get("gender")?.value;
    this.signUpData.age=this.signUpForm.get("age")?.value;

    this.registerService.addUser(this.signUpData).subscribe({
      next:(data:any)=>{
        this.userFailed=false;
        this.passwordFailed=false;
        if(data.status=="UserFailed"){
          this.userFailed=true;
        }
        if(data.status=="PasswordFailed"){
          this.passwordFailed=true;
        }
        if(data.status=="Success"){
          this.passwordFailed=false
          this.userFailed=false
          
          this.router.navigate(["/login"]).then(() => {
            // Show SweetAlert2 notification after navigation
            Swal.fire({
              icon: 'success',
              title: `Registered ${this.signUpForm.value.username} successfully`,
              //text: 'You are now part of a community focused on health and wellness!',
              timer: 3000, 
              timerProgressBar: false,
              showConfirmButton: false,
              customClass: {
                confirmButton: 'custom-confirm-button'
              }
            });
          });
        }
        console.log(data);
      },
      error:(error)=>{
        //console.log(error);
      },
      complete:()=>{
        // this.passwordFailed=false
        // this.userFailed=false
        // console.log("User registration successfull!");
      }
    })
  }

}
