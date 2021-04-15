using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Associate_FacingAPIs.BusinessObjects
{
    public class WhiteList
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public string Reason { get; set; }
        public string Source { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public string CreatedBy { get; set; }
    }
}
