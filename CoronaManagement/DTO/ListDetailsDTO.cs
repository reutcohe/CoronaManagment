using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListDetailsDTO
    {


        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Adress { get; set; }
        public DateTime? LastNegative { get; set; }
        public DateTime? LastPositive { get; set; }

       // public string CompanyName { get; set; }
       public List<DateTime?> AllVaccineDates { get; set; }

         public virtual ICollection<CoronaVaccineDTO> CoronaVaccines { get; set; }
        // public virtual ICollection<ListOpatient> ListOpatients { get; set; }
    }
}
