using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public partial class MRQ_DetailsConfiguration : IEntityTypeConfiguration<MRQ_Details>
    {
        public void Configure(EntityTypeBuilder<MRQ_Details> entity)
        {
            entity.HasKey(e => e.RefId)
                .HasName("PK_MRQ_Details_Ref_Id");

            entity.ToTable("MRQ_Details", "Purchase");

            entity.Property(e => e.RefId).HasColumnName("Ref_Id");

            entity.Property(e => e.HdrRefIdFk).HasColumnName("Hdr_Ref_Id_Fk");

            entity.Property(e => e.ItemMasterNo).HasColumnName("Item_Master_No");

            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.HdrRefIdFkNavigation)
                .WithMany(p => p.MRQ_Details)
                .HasForeignKey(d => d.HdrRefIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Hdr_Ref_Id_Fk_MRQ_Details_To_Purchase.MRQ_Hdr");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MRQ_Details> entity);
    }
}
