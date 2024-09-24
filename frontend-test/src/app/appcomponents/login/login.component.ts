import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { authGuard } from '../../guards/auth.guard';
import { AuthService } from '../../services/auth.service';
import { Login } from '../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  invalidLogin: boolean = false;
  isLoading = false;

  constructor(private router: Router, private fb: FormBuilder, private authservice: AuthService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

  }
  ngOnInit(): void {
    if (this.authservice.isLoggedIn()) {
      this.router.navigate(['home']);
    }
  }

  loginData: Login = {
    userName: '',
    password: ''
  }

  login(): void {
    this.isLoading = true;
    this.loginData.userName = this.loginForm.get("username")?.value;
    this.loginData.password = this.loginForm.get("password")?.value;
    this.authservice.getToken(this.loginData).subscribe({
      next: (data: any) => {
        this.invalidLogin = false;
        const token = data.token;
        const lastlogin=data.lastlogindate;
        localStorage.setItem("jwt", token);
        localStorage.setItem("lastlogindate",lastlogin);
        // Schedule removal of token
        setTimeout(() => {
          this.authservice.logout()
        }, 5 * 60 * 1000);
        //console.log(data);

        //console.log(this.authservice.tokenPresentOrNot());
        // console.log(this.authservice.isLoggedIn());
        // console.log([authGuard]);
        this.router.navigate(["home"]).then(() => {
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
      error: (error) => {
        console.log(error);
        this.invalidLogin = true;
        this.isLoading = false;
        // if(error.status==401){

        // }
      },
      complete: () => {
        this.invalidLogin = false;
        this.isLoading = false;
        console.log('Login request successful!Token Recieved!')
      }
    })

  }





}
