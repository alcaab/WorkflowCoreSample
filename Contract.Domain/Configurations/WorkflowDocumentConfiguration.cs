using Contract.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contract.Domain.Configurations
{
    public class WorkflowDocumentConfiguration : IEntityTypeConfiguration<WorkflowDocument>
    {
        public void Configure(EntityTypeBuilder<WorkflowDocument> entity)
        {
            entity.HasKey(p => p.Id);

            entity.HasIndex(k => new
            {
                k.DocumentRefId,
                k.DocumentType,
                k.WorkflowDefinitionId,
                k.Version
            });

            entity.Property(e => e.Id).HasMaxLength(36);

            entity.Property(e => e.WorkflowId).HasMaxLength(36);

            entity.Property(e => e.DocumentRefId).HasMaxLength(36);

            entity.Property(e => e.WorkflowDefinitionId).HasMaxLength(200);

            entity.Ignore(p => p.IsNew);

            entity
                .HasMany(r=> r.TasksHistory)
                .WithOne()
                .HasPrincipalKey(p=> p.Id)
                .HasForeignKey(k => k.DocumentId);
        }
    }
}