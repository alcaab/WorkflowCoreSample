using Contract.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contract.Domain.Configurations
{
    public class DocumentTaskHistoryConfiguration : IEntityTypeConfiguration<DocumentTaskHistory>
    {
        public void Configure(EntityTypeBuilder<DocumentTaskHistory> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.TaskId).HasMaxLength(36);

            entity.Property(e => e.DocumentId).HasMaxLength(36);

            entity.Property(e => e.TaskDescription).HasMaxLength(200);

            entity.Property(e => e.TaskName).HasMaxLength(100);

            entity.Property(e => e.CreateBy).HasMaxLength(100);

   

        }
    }
}