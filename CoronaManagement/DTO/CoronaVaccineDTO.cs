using System;

namespace DTO
{
    public class CoronaVaccineDTO
    {
        
        public int LineCode { get; set; }
        public string PatientId { get; set; }
        public string ManufacturerId { get; set; }
        public DateTime? DateV { get; set; }
        public int? CounterV { get; set; }

        //public virtual VaccineManufacturer Manufacturer { get; set; }
        //public virtual Patient Patient { get; set; }
    }
}
