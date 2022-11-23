using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("statuses");

            #region <Properties>
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ActionName)
                .HasColumnName("action_name")
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region <Relations>
            builder.HasMany(s => s.Tasks)
                .WithOne(t => t.Status)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Jobs)
                .WithOne(j => j.Action)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
