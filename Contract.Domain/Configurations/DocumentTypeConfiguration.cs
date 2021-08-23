using System;
using Contract.Domain.Enums;
using Contract.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contract.Domain.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedNever();

            entity.Property(p => p.Name).HasMaxLength(100);

            var items = Enum.GetValues(typeof(DocumentTypeEnum));
            foreach (var item in items)
            {
                entity.HasData(new DocumentType
                {
                    Id = (int)item,
                    Name  = Helper.GetEnumerationDescription((DocumentTypeEnum)item)
                });
            }
        }
    }
}
