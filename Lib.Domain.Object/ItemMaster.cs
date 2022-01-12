using System;

namespace Lib.Domain.Object
{
    public class ItemMaster
    {
        public Guid ItemMasterId { get; set; }
        public Guid ItemGrpId { get; set; }
        public string ItemDescription { get; set; }
        public int StockUnit { get; set; }
        public int UnitWeight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastModifiedBy { get; set; }

        //Navigation
        public virtual Employee_Master CreatedByNavigation { get; set; }
        public virtual ItemGroup ItemGrp { get; set; }
        public virtual Employee_Master LastModifiedByNavigation { get; set; }
    }
}