using System;

namespace Lib.Domain.Object
{
    public class MRQ_Details
    {
        public long RefId { get; set; }
        public long HdrRefIdFk { get; set; }
        public Guid? ItemMasterNo { get; set; }
        public short Sno { get; set; }
        public double? Qty { get; set; }
        public string Notes { get; set; }

        //Navigation
        public virtual MRQ_Header HdrRefIdFkNavigation { get; set; }
    }
}