using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListOpatientDTO
    {
        public int LineCode { get; set; }
        public string PatientId { get; set; }
        public DateTime? DatePositive { get; set; }
        public DateTime? DateNegative { get; set; }

       // public virtual Patient Patient { get; set; }
    }
}
