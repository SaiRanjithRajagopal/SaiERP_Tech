using System;
using System.Collections.Generic;

namespace Lib.Domain.Object
{
    public class MRQ_Header
    {
        public MRQ_Header()
        {
            MRQ_Details = new HashSet<MRQ_Details>();
        }
        public long RefId { get; set; }
        public byte TotalItems { get; set; }
        public long CreatedBy { get; set; }
        public long LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //Navigation
        public virtual Employee_Master CreatedByNavigation { get; set; }
        public virtual Employee_Master LastModifiedByNavigation { get; set; }
        public virtual ICollection<MRQ_Details> MRQ_Details { get; set; }
    }
}