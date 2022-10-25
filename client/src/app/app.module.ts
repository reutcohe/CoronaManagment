import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PatientsComponent } from './components/patients/patients.component';
import { HomComponent } from './components/hom/hom.component';
import { UpDatePatientComponent } from './components/up-date-patient/up-date-patient.component';
import { AddPatientComponent } from './components/add-patient/add-patient.component';
import { HomService } from './services/hom.service';
import { PatientService } from './services/patient.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
//import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatSelect } from '@angular/material/select';
import {MatDividerModule} from '@angular/material/divider';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatDialogModule} from '@angular/material/dialog';
import {  HttpClientModule } from '@angular/common/http';
import { patientsBass } from './classes/patientBass';


@NgModule({
  declarations: [
    AppComponent,
    PatientsComponent,

    UpDatePatientComponent,
    AddPatientComponent,
    HomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatDividerModule,
    MatInputModule,
   MatListModule,
   HttpClientModule
    // MatSelect
  ],
  providers: [HomService, PatientService],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
