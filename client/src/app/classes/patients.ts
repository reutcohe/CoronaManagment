export class patients{
   
    constructor(

        public  patientId :string='',
        public patientFullName :string='',
        public  dateOfBirth ?:Date,
        public  phone?:string,
        public  mobilePhone ?:string,
        public  adress?:string,
        public  lastNegative?:Date,
        public  lastPositive?:Date,
        public  allVaccineDates?:Date[],

       // public  CoronaVaccines?: patients

       
       
       
        

       // public string CompanyName { get; set; }
      

        // public virtual ICollection<CoronaVaccineDTO> CoronaVaccines { get; set; }
    ) {
      
    }
}