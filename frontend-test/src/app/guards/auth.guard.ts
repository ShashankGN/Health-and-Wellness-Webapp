import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';


export const authGuard: CanActivateFn = (route, state) :boolean=> {
  const authservice=inject(AuthService);
  const router=inject(Router);
  // console.log("hi");

  // return authService.isLoggedIn().pipe(
  //   map(isLoggedIn=>{
  //     if(!isLoggedIn){
  //       router.navigate(['/login']);
  //       return false;
  //     }
  //     return true;
  //   })
  // )
  if(!authservice.isLoggedIn()){
    
    router.navigate(['login']);
    return false;
  }
  return true;
};
