using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class VaccineManufacturer
    {
        public VaccineManufacturer()
        {
            CoronaVaccines = new HashSet<CoronaVaccine>();
        }

        public string CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<CoronaVaccine> CoronaVaccines { get; set; }
    }
}
