using Lib.Domain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Data.Configurations
{
    public class EmployeeMasterConfiguration : IEntityTypeConfiguration<Employee_Master>
    {
        public void Configure(EntityTypeBuilder<Employee_Master> entity)
        {
            entity.HasKey(e => e.EmployeeId)
                .HasName("PK_Employee_Id");

            entity.ToTable("Employee_Master", "Hrms");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

            entity.Property(e => e.Address)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_Of_Birth");

            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("First_Name");

            entity.Property(e => e.Homephone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.JoinDate)
                .HasColumnType("date")
                .HasColumnName("Join_Date");

            entity.Property(e => e.LastName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Last_Name");

            entity.Property(e => e.PostCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Post_Code");

            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Workphone)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
