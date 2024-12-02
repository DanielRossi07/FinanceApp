using Finance.Domain.Entity;
using Finance.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.EF
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<TransactionCategory> TransactionCategories => Set<TransactionCategory>();
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionCategoryConfiguration());
        }
    }
}
