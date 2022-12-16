using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            #region <Properties>
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(4000);
            #endregion

            #region <Relations>
            builder.HasOne(j => j.Issue)
                .WithMany(i => i.Jobs)
                .HasForeignKey(j => j.IssueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Executor)
                .WithMany(s => s.ExecutorOfJobs)
                .HasForeignKey(p => p.ExecutorId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
