using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public partial class MRQ_HeaderConfiguration : IEntityTypeConfiguration<MRQ_Header>
    {
        public void Configure(EntityTypeBuilder<MRQ_Header> entity)
        {
            entity.HasKey(e => e.RefId)
                .HasName("PK_MRQ_Hdr_Ref_Id");

            entity.ToTable("MRQ_Hdr", "Purchase");

            entity.Property(e => e.RefId).HasColumnName("Ref_Id");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.LastModifiedBy).HasColumnName("LastModified_By");

            entity.Property(e => e.LastModifiedDate).HasColumnType("date");

            entity.Property(e => e.TotalItems).HasColumnName("Total_Items");

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.MRQ_Header_CreatedBy_Navigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Created_By_MRQ_Hdr_To_Hrms.Employee_Master");

            entity.HasOne(d => d.LastModifiedByNavigation)
                .WithMany(p => p.MRQ_Header_LastModifiedBy_Navigation)
                .HasForeignKey(d => d.LastModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastModified_By_MRQ_Hdr_To_Hrms.Employee_Master");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MRQ_Header> entity);
    }
}
