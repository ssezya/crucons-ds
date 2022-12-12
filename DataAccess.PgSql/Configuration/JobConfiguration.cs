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
            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.IssueId)
                .IsRequired();

            builder.Property(p => p.ActionId)
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasOne(j => j.Creator)
                .WithMany(t => t.CreatedJobs)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.LastModificator)
                .WithMany(t => t.LastModifiedJobs)
                .HasForeignKey(p => p.LastModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Issue)
                .WithMany(t => t.Jobs)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Action)
                .WithMany(s => s.Jobs)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
