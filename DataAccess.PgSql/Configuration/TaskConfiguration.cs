using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("tasks");

            #region <Properties>
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(p => p.CreatorId)
                .HasColumnName("creator_id")
                .IsRequired();

            builder.Property(p => p.StatusId)
                .HasColumnName("status_id")
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasOne(t => t.Creator)
                .WithMany(u => u.Tasks)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Status)
                .WithMany(s => s.Tasks)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.Jobs)
                .WithOne(j => j.Task)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}