using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            #region <Properties>
            builder.Property(p => p.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasMany(e => e.CreatedIssues)
                .WithOne(i => i.Creator)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.LastModifiedIssues)
                .WithOne(i => i.LastModificator)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.CreatedJobs)
                .WithOne(j => j.Creator)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.LastModifiedJobs)
                .WithOne(j => j.LastModificator)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
