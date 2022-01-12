using System;
using System.Collections.Generic;

namespace Lib.Domain.Object
{
    public class Supplier_Master
    {
        public Supplier_Master()
        {
            purchaseOrder_Header = new HashSet<PurchaseOrder_Header>();
        }
        public long SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //Navigation
        public virtual Employee_Master CreatedByNavigation { get; set; }
        public virtual Employee_Master ModifiedByNavigation { get; set; }
        public virtual ICollection<PurchaseOrder_Header> purchaseOrder_Header { get; set; }
    }
}