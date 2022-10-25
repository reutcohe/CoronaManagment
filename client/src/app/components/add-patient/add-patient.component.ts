import { Component, OnInit } from '@angular/core';
import { patients } from 'src/app/classes/patients';
import { PatientService } from 'src/app/services/patient.service';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatChipsModule} from '@angular/material/chips';
import {MatInputModule} from '@angular/material/input';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { formatCurrency } from '@angular/common';



@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {

  constructor(private patientService:PatientService) { }
  addPatientForm!: FormGroup
  // count:number=0
  // ifNo4:boolean=false
  ngOnInit(): void {
    this.addPatientForm=new FormGroup({
      id:new FormControl(["", Validators.required,Validators.pattern('[0-9]*')]),
      fullName:new FormControl("", Validators.required),
      city:new FormControl(),
      street:new FormControl(),
      numStreet:new FormControl(),
      phone:new FormControl("", Validators.required),
      DateOfBirth:new FormControl("", Validators.required),
      dateOfPositive:new FormControl(),
      dateOfNegative:new FormControl(),
      phoneMobile: new  FormControl()

    })
  }
  newPatient!:patients
addPtient(){
console.log(this.addPatientForm)
 // this.patientService.setPtient(patient);
 
 this.newPatient = new patients(
  this.addPatientForm.value.id,
  this.addPatientForm.value.fullName,
  this.addPatientForm.value.DateOfBirth,
  this.addPatientForm.value.phone,
  this.addPatientForm.value.phoneMobile,
  this.addPatientForm.value.city,
  this.addPatientForm.value.street,
  this.addPatientForm.value.numStreet,
 
  
  // this.addPatientForm.value.dateOfPositive,
  // this.addPatientForm.value.dateOfNegative
);
//this.patientService.getAllpatients().push(this.newPatient)
console.log(this.patientService.getAllpatients())
  this.addPatientForm.reset();
}
// showV(){
//   if(this.count<4)
//   this.ifNo4==true


// }
}
