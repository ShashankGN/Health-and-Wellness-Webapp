import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Login } from '../../../core/models/Login';
import { LoginService } from '../../../core/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  invalidLogin: boolean = false;
  
  constructor(private router:Router,private fb: FormBuilder,private loginService:LoginService){
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
    
  }

  loginData:Login={
    userName:'',
    password:''
  }

  login():void{
    this.loginData.userName=this.loginForm.get("username")?.value;
    this.loginData.password=this.loginForm.get("password")?.value;
    this.loginService.getToken(this.loginData).subscribe({
      next:(data:any)=>{
        this.invalidLogin=false;
        const token=data.token;
        localStorage.setItem("jwt",token);
        //console.log(data);
        

        this.router.navigate(["/home"]).then(() => {
          // Show SweetAlert2 notification after navigation
          Swal.fire({
            icon: 'success',
            title: `Welcome ${this.loginForm.value.username}`,
            text: 'You are now part of a community focused on health and wellness!',
            timer: 3000, 
            timerProgressBar: false,
            showConfirmButton: false,
            customClass: {
              confirmButton: 'custom-confirm-button'
            }
          });
        });
      
        //alert(`Welcome ${this.loginData.userName}`);
        
      },
      error:(error)=>{
        console.log(error);
        this.invalidLogin=true;
        // if(error.status==401){

        // }
      },
      complete:()=>{
        this.invalidLogin=false;
        console.log('Login request successful!Token Recieved!')
      }
    })

  }
  

  
  
  


}
