import { Injectable } from '@angular/core';
import { patients } from '../classes/patients';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { patientsBass } from '.././classes/patientBass';

const V_API=environment.apiUrl+'/Patient/';
@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }
  private AllPatients:patients[]=[
    new patients("318528833","reut cohen",new Date(1997,11,5),"0583277661","025765555","hrf",new Date(1997,11,5),new Date(1997,11,5)),
    new patients("318528833","reut cohen",new Date(1997,11,5),"0583277661","025765555","hrf",new Date(1997,11,5),new Date(1997,11,5)),
    new patients("318528833","reut cohen",new Date(1997,11,5),"0583277661","025765555","hrf",new Date(1997,11,5),new Date(1997,11,5)),

  ]
  
  getAllpatients():Observable <patientsBass[]>{
    //return this.AllPatients;
    return this.http.get<patientsBass[]>(V_API+'GetAll');
    }
    ExistLInlist?:string
  
    getPatientById(patientID:string):Observable <patients>{
      //למה זה לא טוב?
      return this.http.get<patients>(V_API+`GetByIdFullInfo/${patientID}`);
     
    }
    deletePtient(patient: patients):void{
let index:number= this.AllPatients.indexOf(patient);
if(index!=-1)
this.AllPatients.splice(index,1);
    }
    setPtient(patient:patients){
      this.AllPatients.forEach(element => {
       if(element.patientFullName!=patient.patientFullName&&element.patientId!=patient.patientId)
       this.AllPatients.push(patient);
       else
       this.ExistLInlist="קיים ברשימה"
      });
}
    
  }

