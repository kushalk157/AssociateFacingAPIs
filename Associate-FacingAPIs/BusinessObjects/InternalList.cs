using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Associate_FacingAPIs.BusinessObjects
{
    public class InternalList
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public string Source { get; set; }
        public string PersonId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public DateTime ExpirationDateUTC { get; set; }
        public DateTime DeactivationDateUTC { get; set; }
        public string DeactivatedBy { get; set; }
        public string DeactivationSource { get; set; }
        public DateTime UpdateDateUTC { get; set; }
    }
}
