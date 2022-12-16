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
            builder.HasMany(e => e.ReporterOfIssues)
                .WithOne(i => i.Reporter)
                .HasForeignKey(i => i.ReporterId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.ExecutorOfIssues)
                .WithOne(i => i.Executor)
                .HasForeignKey(i => i.ExecutorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.ExecutorOfJobs)
                .WithOne(j => j.Executor)
                .HasForeignKey(j => j.ExecutorId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion
        }
    }
}
