import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './appcomponents/landing/landing.component';
import { LoginComponent } from './appcomponents/login/login.component';
import { NotfoundComponent } from './appcomponents/notfound/notfound.component';
import { RegisterComponent } from './appcomponents/register/register.component';
import { authGuard } from './guards/auth.guard';

const routes: Routes = [
  {path:'',component:LandingComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'home',
  canActivate:[authGuard],
  loadChildren:()=>import('./modules/home/home.module').then((m)=>m.HomeModule)},
  {path:'**',component:NotfoundComponent}
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
