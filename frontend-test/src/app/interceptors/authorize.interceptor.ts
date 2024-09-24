import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';


export const authorizeInterceptor: HttpInterceptorFn = (req, next) => {
  // debugger;
  const authservice=inject(AuthService);
  const token=authservice.tokenPresentOrNot();
  const clonedRequest=req.clone({
    setHeaders:{
      Authorization:`Bearer ${token}`
    }
  })
  // console.log(clonedRequest);
  return next(clonedRequest);
};
