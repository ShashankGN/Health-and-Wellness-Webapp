import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomizedmealplanRoutingModule } from './customizedmealplan-routing.module';
import { CmpdashComponent } from './components/cmpdash/cmpdash.component';
import { CmphomeComponent } from './components/cmphome/cmphome.component';
import { CmprecipeComponent } from './components/cmprecipe/cmprecipe.component';
import { CmpbmiComponent } from './components/cmpbmi/cmpbmi.component';
import { CmptargetcalorieComponent } from './components/cmptargetcalorie/cmptargetcalorie.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';
import { CaloriegainedComponent } from './components/caloriegained/caloriegained.component';
import { TargetgaincaloriemodalComponent } from './components/targetgaincaloriemodal/targetgaincaloriemodal.component';


@NgModule({
  declarations: [
    CmpdashComponent,
    CmphomeComponent,
    CmprecipeComponent,
    CmpbmiComponent,
    CmptargetcalorieComponent,
    CaloriegainedComponent,
    TargetgaincaloriemodalComponent
  ],
  imports: [
    CommonModule,
    CustomizedmealplanRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers:[
    // provideHttpClient()
  ]
})
export class CustomizedmealplanModule { }
