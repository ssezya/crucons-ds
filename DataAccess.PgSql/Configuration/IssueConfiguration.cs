using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("issues");

            #region <Properties>
            builder.Property(p => p.IssueId)
                .HasColumnName("issue_id");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();

            builder.Property(p => p.LastModifiedAt)
                .HasColumnName("last_modified_at");

            builder.Property(p => p.LastModifiedBy)
                .HasColumnName("last_modified_by");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.StatusId)
                .HasColumnName("status_id")
                .HasDefaultValue(1)
                .IsRequired();
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