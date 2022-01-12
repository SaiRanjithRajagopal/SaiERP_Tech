using Lib.Domain.Object;
using Lib.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Lib.Infra.Data
{
    public partial class Sai_ERPContext : DbContext
    {
        public Sai_ERPContext()
        {
        }

        public Sai_ERPContext(DbContextOptions<Sai_ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee_Master> EmployeeMaster { get; set; }
        public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        public virtual DbSet<Supplier_Master> Master { get; set; }
        public virtual DbSet<MRQ_Details> MrqDetails { get; set; }
        public virtual DbSet<MRQ_Header> MrqHdr { get; set; }
        public virtual DbSet<PurchaseOrder_Header> PoHdr { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMasterConfiguration());
            modelBuilder.ApplyConfiguration(new ItemGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ItemMasterConfiguration());
            modelBuilder.ApplyConfiguration(new Supplier_MasterConfiguration());
            modelBuilder.ApplyConfiguration(new MRQ_DetailsConfiguration());
            modelBuilder.ApplyConfiguration(new MRQ_HeaderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrder_HeaderConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
