import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CaloriegainedComponent } from './components/caloriegained/caloriegained.component';
import { CmpbmiComponent } from './components/cmpbmi/cmpbmi.component';
import { CmpdashComponent } from './components/cmpdash/cmpdash.component';
import { CmphomeComponent } from './components/cmphome/cmphome.component';
import { CmprecipeComponent } from './components/cmprecipe/cmprecipe.component';
import { CmptargetcalorieComponent } from './components/cmptargetcalorie/cmptargetcalorie.component';

const routes: Routes = [
  {path:'',component:CmpdashComponent,
  children:[
    {path:'cmphome',component:CmphomeComponent},
    {path:'recipe',component:CmprecipeComponent},
    {path:'bmi',component:CmpbmiComponent},
    {path:'calorie',component:CmptargetcalorieComponent},
    {path:'caloriegained',component:CaloriegainedComponent},
    {path:'',redirectTo:'/home/features/cmp/cmphome',pathMatch:'full'}

  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomizedmealplanRoutingModule { }
