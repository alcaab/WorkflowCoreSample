using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contract.Domain.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Domain.Models.Contract>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Contract> entity)
        {
            entity.HasKey(p => p.Id);

        }
    }
}