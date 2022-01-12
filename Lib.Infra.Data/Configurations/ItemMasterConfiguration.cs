using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lib.Infra.Data.Configurations
{
    public class ItemMasterConfiguration : IEntityTypeConfiguration<ItemMaster>
    {
        public void Configure(EntityTypeBuilder<ItemMaster> entity)
        {
            entity.ToTable("Item_Master", "Inventory");

            entity.Property(e => e.ItemMasterId)
                .ValueGeneratedNever()
                .HasColumnName("Item_Master_Id");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("Created_Date");

            entity.Property(e => e.ItemDescription)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Item_Description");

            entity.Property(e => e.ItemGrpId).HasColumnName("Item_Grp_Id");

            entity.Property(e => e.LastModifiedBy).HasColumnName("LastModified_By");

            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("date")
                .HasColumnName("LastModified_Date");

            entity.Property(e => e.StockUnit).HasColumnName("Stock_Unit");

            entity.Property(e => e.UnitWeight).HasColumnName("Unit_Weight");

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.ItemMaster_CreatedBy_Navigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Created_By_To_Hrms_Employee_Master");

            entity.HasOne(d => d.ItemGrp)
                .WithMany(p => p.ItemMaster)
                .HasForeignKey(d => d.ItemGrpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Grp_Id_To_Item_Master");

            entity.HasOne(d => d.LastModifiedByNavigation)
                .WithMany(p => p.ItemMaster_LastModifiedBy_Navigation)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_LastModified_By_To_Hrms_Employee_Master");
        }
    }
}
