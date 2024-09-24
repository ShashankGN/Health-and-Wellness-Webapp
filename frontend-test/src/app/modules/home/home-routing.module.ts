import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactusComponent } from './components/contactus/contactus.component';
import { HomedashComponent } from './components/homedash/homedash.component';
import { StartComponent } from './components/start/start.component';

const routes: Routes = [
  {path:'',component:HomedashComponent,children:[
    {path:'start',component:StartComponent},
    {path:'contact',component:ContactusComponent},
    {path:'features',loadChildren:()=>import('./modules/features/features.module').then((m)=>m.FeaturesModule)},
    {path:'',redirectTo:'/home/start',pathMatch:'full'}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
