using Finance.Domain.Entity;
using Finance.Domain.SeedWork;
using Finance.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.EF
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<TransactionCategory> TransactionCategories => Set<TransactionCategory>();
        public DbSet<BankAccount> BankAccount => Set<BankAccount>();
        public DbSet<TransactionSource> TransactionSource => Set<TransactionSource>();
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionSourceConfiguration());
        }
    }
}
