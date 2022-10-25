import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { patients } from 'src/app/classes/patients';
import { PatientService } from 'src/app/services/patient.service';
import {MatListModule} from '@angular/material/list';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { patientsBass } from 'src/app/classes/patientBass';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit {
  Id: string="318528833"
  thisPtient!:patients
  constructor(private myActiv: ActivatedRoute,private patientService:PatientService,
   // public dialogRef: MatDialogRef<PatientsComponent>,
   // @Inject(MAT_DIALOG_DATA)public data: DialogData
    
    ) { }

  ngOnInit(): void {
    // this.myActiv.params.subscribe(
    //   data => {
    //     this.Id = data["id"]
    //     this.thisPtient = this.patientService.getPatientById(this.Id);
    //      console.log(this.thisPtient);
    this.patientService.getPatientById(this.Id).subscribe((x)=>{
      this.thisPtient = x;
      console.log(x );
      
    })
      
  
  }
}
