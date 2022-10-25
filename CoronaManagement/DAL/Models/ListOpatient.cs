using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class ListOpatient
    {
        public int LineCode { get; set; }
        public string PatientId { get; set; }
        public DateTime? DatePositive { get; set; }
        public DateTime? DateNegative { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
