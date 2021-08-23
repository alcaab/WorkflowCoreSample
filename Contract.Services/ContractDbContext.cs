using Microsoft.EntityFrameworkCore;

namespace Contract.Services
{
    public class ContractDbContext:DbContext
    {
        public ContractDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Domain.Models.Contract).Assembly);
        }
    }
}
