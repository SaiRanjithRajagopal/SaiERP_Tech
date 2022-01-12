using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public class ItemGroupConfiguration : IEntityTypeConfiguration<ItemGroup>
    {
        public void Configure(EntityTypeBuilder<ItemGroup> entity)
        {
            entity.HasKey(e => e.GroupId)
                .HasName("PK_Item_Group_Group_Id");

            entity.ToTable("Item_Group", "Inventory");

            entity.Property(e => e.GroupId)
                .ValueGeneratedNever()
                .HasColumnName("Group_Id");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("Created_Date");

            entity.Property(e => e.GroupCode).HasColumnName("Group_Code");

            entity.Property(e => e.GroupCodeName)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Group_Code_Name");

            entity.Property(e => e.LastModifiedBy).HasColumnName("LastModified_By");

            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("date")
                .HasColumnName("LastModified_Date");

            entity.Property(e => e.SubGroupCode).HasColumnName("Sub_Group_Code");

            entity.Property(e => e.SubGroupCodeName)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Sub_Group_Code_Name");

            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.ItemGroup_CreatedBy_Navigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Created_By_Item_Group_To_Hrms.Employee_Master");

            entity.HasOne(d => d.LastModifiedByNavigation)
                .WithMany(p => p.ItemGroup_LastModifiedBy_Navigation)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_LastModified_By_Item_Group_To_Hrms.Employee_Master");
        }
    }
}
