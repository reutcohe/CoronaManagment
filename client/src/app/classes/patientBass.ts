export class patientsBass{
   
    constructor(

        public  patientId :string='',
        public patientFullName :string='',
        public  dateOfBirth ?:Date,
        public  phone?:string,
        public  mobilePhone ?:string,
        public  city?:string,
        public  street?:string,
        public  numStreet?:string,
        public  allVaccineDates?:Date[],
        public lastPositive?:string,
        public  lastNegative?:string
       //  public virtual ICollection<CoronaVaccineDTO> CoronaVaccines { get; set; }



       
        
        
        
    ) {
      
    }
}
        
        // public virtual ICollection<CoronaVaccine> CoronaVaccines { get; set; }
        // public List<DateTime?> AllVaccineDates => CoronaVaccines.Select(x => x.DateV).ToList();

       
       
        // public DateTime?  LastNegative=> ListOpatients.Max(x=>x.DateNegative);