import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExerciseworkoutRoutingModule } from './exerciseworkout-routing.module';
import { ExercisedashComponent } from './components/exercisedash/exercisedash.component';
import { ExercisehomeComponent } from './components/exercisehome/exercisehome.component';
import { CustomizedexerciseComponent } from './components/customizedexercise/customizedexercise.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalorieburntComponent } from './components/calorieburnt/calorieburnt.component';
import { TargetcaloriemodalComponent } from './components/targetcaloriemodal/targetcaloriemodal.component';


@NgModule({
  declarations: [
    ExercisedashComponent,
    ExercisehomeComponent,
    CustomizedexerciseComponent,
    CalorieburntComponent,
    TargetcaloriemodalComponent
    ],
  imports: [
    CommonModule,
    FormsModule,
    ExerciseworkoutRoutingModule,
    ReactiveFormsModule
  ]
})
export class ExerciseworkoutModule { }
