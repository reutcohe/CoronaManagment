import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UpDatePatientComponent } from './components/up-date-patient/up-date-patient.component';
import { AddPatientComponent } from './components/add-patient/add-patient.component';
import { HomComponent } from './components/hom/hom.component';
import { PatientsComponent } from './components/patients/patients.component';


const routes: Routes = [

  {path:"",component:HomComponent},
  {path:"update/:id",component:UpDatePatientComponent},
  {path:"add",component:AddPatientComponent},
  {path:"moreD/:id",component:PatientsComponent},
  {path:"back",component:HomComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
