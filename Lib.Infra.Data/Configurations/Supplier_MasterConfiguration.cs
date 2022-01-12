using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public class Supplier_MasterConfiguration : IEntityTypeConfiguration<Supplier_Master>
    {
        public void Configure(EntityTypeBuilder<Supplier_Master> entity)
        {
            entity.HasKey(e => e.SupplierId)
                .HasName("PK__tmp_ms_x__83918DB8D4E18EE8");

            entity.ToTable("Master", "Supplier");

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

            entity.Property(e => e.Address)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.ContactName)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Contact_Name");

            entity.Property(e => e.ContactNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Contact_No");

            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Email_Address");

            entity.Property(e => e.LastModifiedDate).HasColumnType("date");

            entity.Property(e => e.PostCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.SupplierMaster_CreatedBy_Navigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_CreatedBy_To_Hrms_Employee_Master");

            entity.HasOne(d => d.ModifiedByNavigation)
                .WithMany(p => p.SupplierMaster_ModifiedBy_Navigation)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_ModifiedBy_To_Hrms_Employee_Master");
        }
    }
}
