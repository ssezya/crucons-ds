using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region <Properties>
            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
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
