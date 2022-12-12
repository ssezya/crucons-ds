using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            #region <Properties>
            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.StatusId)
                .IsRequired()
                .HasDefaultValue(1);
            #endregion

            #region <Relations>
            builder.HasOne(i => i.Creator)
                .WithMany(e => e.CreatedIssues)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.LastModificator)
                .WithMany(e => e.LastModifiedIssues)
                .HasForeignKey(p => p.LastModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Status)
                .WithMany(s => s.Issues)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(i => i.Jobs)
                .WithOne(j => j.Issue)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}