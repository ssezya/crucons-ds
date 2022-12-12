using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            #region <Properties>
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50);

            builder.Property(p => p.ActionName)
                .IsRequired()
                .HasColumnName("action_name")
                .HasMaxLength(50);
            #endregion

            #region <Relations>
            builder.HasMany(s => s.Issues)
                .WithOne(t => t.Status)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Jobs)
                .WithOne(j => j.Action)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
