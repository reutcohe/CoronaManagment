import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { HomService } from 'src/app/services/hom.service';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-up-date-patient',
  templateUrl: './up-date-patient.component.html',
  styleUrls: ['./up-date-patient.component.css']
})
export class UpDatePatientComponent implements OnInit {

  constructor(
    private myActiv: ActivatedRoute, private patientService: PatientService,
    private homService: HomService, dialogRef: MatDialogRef<UpDatePatientComponent> 
    ) {

   
     }
    public dialogRef!: MatDialogRef<UpDatePatientComponent> 
    @Inject(MAT_DIALOG_DATA) public data:any
  Id!: string
  thisPatient: any

  ngOnInit(): void {
    console.log(this.data)
    this.thisPatient=this.data
    // this.myActiv.params.subscribe(
    //   data => {
    //     this.Id = data["id"]
    //     this.thisPatient = this.patientService.getPatientById(this.Id);
    //     console.log(this.thisPatient);
    //     this.thisPatient= this.patientService.getPatientById(this.Id)
    //   }
      
    // )
    
  }
  onNoClick(): void {
    this.dialogRef.close();
    
  }

}
