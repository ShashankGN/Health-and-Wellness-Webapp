import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FeaturesRoutingModule } from './features-routing.module';
import { FeaturesdashComponent } from './components/featuresdash/featuresdash.component';
import { FacilitiesComponent } from './components/facilities/facilities.component';


@NgModule({
  declarations: [
    FeaturesdashComponent,
    FacilitiesComponent
  ],
  imports: [
    CommonModule,
    FeaturesRoutingModule
  ]
})
export class FeaturesModule { }
