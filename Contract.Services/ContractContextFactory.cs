using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Contract.Services
{
    public class ContractContextFactory : IDesignTimeDbContextFactory<ContractDbContext>
    {
        public ContractDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ContractDbContext>();
            builder.UseSqlServer(
                @"Server=.;Database=WfCoreDb;Trusted_Connection=True;MultipleActiveResultSets=True");

            return new ContractDbContext(builder.Options);
        }
    }
}
