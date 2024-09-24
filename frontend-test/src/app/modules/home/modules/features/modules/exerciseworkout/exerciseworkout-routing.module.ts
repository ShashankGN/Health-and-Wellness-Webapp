import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalorieburntComponent } from './components/calorieburnt/calorieburnt.component';
import { CustomizedexerciseComponent } from './components/customizedexercise/customizedexercise.component';
import { ExercisedashComponent } from './components/exercisedash/exercisedash.component';
import { ExercisehomeComponent } from './components/exercisehome/exercisehome.component';

const routes: Routes = [
  {path:'',component:ExercisedashComponent,children:[
    {path:'exercisehome',component:ExercisehomeComponent},
    {path:'customexercise',component:CustomizedexerciseComponent},
    {path:'calorieburnt',component:CalorieburntComponent},
    {path:'',redirectTo:'/home/features/exercise/exercisehome',pathMatch:'full'}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExerciseworkoutRoutingModule { }
