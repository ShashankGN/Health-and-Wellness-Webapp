import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FacilitiesComponent } from './components/facilities/facilities.component';
import { FeaturesdashComponent } from './components/featuresdash/featuresdash.component';

const routes: Routes = [
  {path:'',component:FeaturesdashComponent,
  children:[
    {path:'facilities',component:FacilitiesComponent},
    {path:'',redirectTo:'/home/features/facilities',pathMatch:'full'},
    {path:'cmp',loadChildren:()=>import('./modules/customizedmealplan/customizedmealplan.module').then((m)=>m.CustomizedmealplanModule)},
    {path:'exercise',loadChildren:()=>import('./modules/exerciseworkout/exerciseworkout.module').then((m)=>m.ExerciseworkoutModule)}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
