using System;
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
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(p => p.CreatorId)
                .HasColumnName("creator_id")
                .IsRequired();

            builder.Property(p => p.TaskId)
                .HasColumnName("task_id")
                .IsRequired();

            builder.Property(p => p.ActionId)
                .HasColumnName("action_id")
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasOne(j => j.Creator)
                .WithMany(u => u.Jobs)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Task)
                .WithMany(t => t.Jobs)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Action)
                .WithMany(s => s.Jobs)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
