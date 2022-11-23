using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            #region <Properties>
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasMany(u => u.Tasks)
                .WithOne(t => t.Creator)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Jobs)
                .WithOne(j => j.Creator)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
