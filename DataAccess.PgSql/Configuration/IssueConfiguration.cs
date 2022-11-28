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

            builder.Property(p => p.LastModifiedAt)
                .HasColumnName("last_modified_at")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.StatusId)
                .HasColumnName("status_id")
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasOne(t => t.Status)
                .WithMany(s => s.Issues)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.Jobs)
                .WithOne(j => j.Issue)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}