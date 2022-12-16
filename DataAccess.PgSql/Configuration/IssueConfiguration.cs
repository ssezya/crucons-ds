using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;
using Entities.Enums;

namespace DataAccess.PgSql.Configuration
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            #region <Properties>
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(4000);

            builder.Property(p => p.StatusId)
                .HasDefaultValue(IssueStatus.New);
            #endregion

            #region <Relations>
            builder.HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Reporter)
                .WithMany(e => e.ReporterOfIssues)
                .HasForeignKey(i => i.ReporterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Executor)
                .WithMany(e => e.ExecutorOfIssues)
                .HasForeignKey(i => i.ExecutorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(i => i.Jobs)
                .WithOne(j => j.Issue)
                .HasForeignKey(j => j.IssueId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}