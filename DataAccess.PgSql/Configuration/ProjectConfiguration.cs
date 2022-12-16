using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            #region <Properties>
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region <Relations>
            builder.HasMany(p => p.Issues)
                .WithOne(i => i.Project)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
