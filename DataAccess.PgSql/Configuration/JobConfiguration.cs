using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("jobs");

            #region <Properties>
            builder.Property(p => p.JobId)
                .HasColumnName("job_id");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(p => p.LastModifiedAt)
                .HasColumnName("last_modified_at")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(p => p.TaskId)
                .HasColumnName("task_id")
                .IsRequired();

            builder.Property(p => p.ActionId)
                .HasColumnName("action_id")
                .IsRequired();
            #endregion

            #region <Relations>
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
