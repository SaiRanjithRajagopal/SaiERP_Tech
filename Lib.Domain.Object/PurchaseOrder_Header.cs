using System;

namespace Lib.Domain.Object
{
    public class PurchaseOrder_Header
    {
        public long RefId { get; set; }
        public long SupplierId { get; set; }
        public decimal? TotalAmount { get; set; }
        public long CreatedBy { get; set; }
        public long LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //Navigation
        public virtual Employee_Master CreatedByNavigation { get; set; }
        public virtual Employee_Master LastModifiedByNavigation { get; set; }
        public virtual Supplier_Master Supplier { get; set; }
    }
}