import { Component, OnInit } from '@angular/core';
import { HomService } from '../../services/hom.service';
import { patients } from 'src/app/classes/patients';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { UpDatePatientComponent } from '../up-date-patient/up-date-patient.component';
import { PatientService } from 'src/app/services/patient.service';
import { patientsBass } from 'src/app/classes/patientBass';



@Component({
  selector: 'app-hom',
  templateUrl: './hom.component.html',
  styleUrls: ['./hom.component.css']
})
export class HomComponent implements OnInit {
  allPatients!: patientsBass[]
  display: boolean = false;
patientOfUbdate!:patients
o!:patientsBass
  constructor(
    private HomService: HomService, private myRouting: Router, private patientService:PatientService ,
    public dialog: MatDialog
    
  ) { }
  
  ngOnInit(): void {
  this.patientService.getAllpatients().subscribe((x)=>{
    this.allPatients = x;
    console.log(this.allPatients );
  
  })
  
  }
  referId(id: string): void {
    console.log(id)
    //debugger;
    this.myRouting.navigate([`/update/${id}`]);
  }
  add(): void{}
  delete(patient:patients){
   this.patientService.deletePtient(patient);
  }
  FullDetails(id: string){
    this.myRouting.navigate([`/moreD/${id}`]);
  }
  num:number=555
  openDialog(id: string): void {
    const dialogRef = this.dialog.open(UpDatePatientComponent, {
      width: '250px',
      data: {
         id:2
      },
      
    });
    
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.patientOfUbdate = result;
    });
  }
}

  // routAdd(){
  //   this.myRouting.navigate(['/add']);
  // }
  //   showDialog() {
  //     this.display = true;
  // }

  
    //dialogRef.afterClosed().subscribe(result => {
     // console.log('The dialog was closed');
      
    //});

