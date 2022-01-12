using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public partial class PurchaseOrder_HeaderConfiguration : IEntityTypeConfiguration<PurchaseOrder_Header>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder_Header> entity)
        {
            entity.HasKey(e => e.RefId)
                .HasName("PK_PO_Hdr_Ref_Id");

            entity.ToTable("PO_Hdr", "Purchase");

            entity.Property(e => e.RefId).HasColumnName("Ref_Id");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.LastModifiedBy).HasColumnName("LastModified_By");

            entity.Property(e => e.LastModifiedDate).HasColumnType("date");

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

            entity.Property(e => e.TotalAmount)
                .HasColumnType("money")
                .HasColumnName("Total_Amount");

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.PurchaseOrder_Header_CreatedBy_Navigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Created_By_PO_Hdr_To_Hrms.Employee_Master");

            entity.HasOne(d => d.LastModifiedByNavigation)
                .WithMany(p => p.PurchaseOrder_HeaderLastModifiedBy_Navigation)
                .HasForeignKey(d => d.LastModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastModified_By_PO_Hdr_To_Hrms.Employee_Master");

            entity.HasOne(d => d.Supplier)
                .WithMany(p => p.purchaseOrder_Header)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Id_PO_Hdr_To_Supplier.Master");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PurchaseOrder_Header> entity);
    }
}
