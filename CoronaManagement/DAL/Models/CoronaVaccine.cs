using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DAL.Models
{
    public partial class CoronaVaccine
    {
        [Key]
        public int LineCode { get; set; }
        public string PatientId { get; set; }
        public string ManufacturerId { get; set; }
        public DateTime? DateV { get; set; }
        public int? CounterV { get; set; }

        public virtual VaccineManufacturer Manufacturer { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
