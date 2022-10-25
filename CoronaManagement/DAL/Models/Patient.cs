using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace DAL.Models
{
    public partial class Patient
    {
        public Patient()
        {
            CoronaVaccines = new HashSet<CoronaVaccine>();
            ListOpatients = new HashSet<ListOpatient>();
        }

        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? NumStreet { get; set; }

        public virtual ICollection<CoronaVaccine> CoronaVaccines { get; set; }
        public List<DateTime?> AllVaccineDates => CoronaVaccines.Select(x => x.DateV).ToList();

       public virtual ICollection<ListOpatient> ListOpatients { get; set; }
        public DateTime?  LastPositive=> ListOpatients.Max(x=>x.DatePositive);
        public DateTime?  LastNegative=> ListOpatients.Max(x=>x.DateNegative);
    }
}
