using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace DataAccess.PgSql.Configuration
{
    public class IssueNoteConfiguration : IEntityTypeConfiguration<IssueNote>
    {
        public void Configure(EntityTypeBuilder<IssueNote> builder)
        {
            #region <Properties>
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);
            #endregion

            #region <Relations>
            builder.HasOne(n => n.Issue)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.IssueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(n => n.Writer)
                .WithMany(e => e.WriterOfIssueNotes)
                .HasForeignKey(n => n.WriterId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
