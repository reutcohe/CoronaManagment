using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientDTO
    {
        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? NumStreet { get; set; }

        
       //public virtual ICollection<CoronaVaccine> CoronaVaccines { get; set; }
       //  public virtual ICollection<ListOpatient> ListOpatients { get; set; }
    }
}
