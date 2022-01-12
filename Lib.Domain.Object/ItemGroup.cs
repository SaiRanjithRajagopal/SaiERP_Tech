using System;
using System.Collections.Generic;

namespace Lib.Domain.Object
{
    public class ItemGroup
    {
        public ItemGroup()
        {
            ItemMaster = new HashSet<ItemMaster>();
        }

        public Guid GroupId { get; set; }
        public int GroupCode { get; set; }
        public int SubGroupCode { get; set; }
        public string GroupCodeName { get; set; }
        public string SubGroupCodeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastModifiedBy { get; set; }

        //Navigation
        public virtual Employee_Master CreatedByNavigation { get; set; }
        public virtual Employee_Master LastModifiedByNavigation { get; set; }
        public virtual ICollection<ItemMaster> ItemMaster { get; set; }
    }
}