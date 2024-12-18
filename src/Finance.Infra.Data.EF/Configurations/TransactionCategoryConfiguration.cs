using Finance.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.EF.Configurations
{
    internal class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.ToTable("TransactionCategory");

            builder.HasKey(transactionCategory => transactionCategory.Id);

            // Navigation
            //builder.Navigation(transactionCategory => transactionCategory.User).AutoInclude();

            // Relationships
            //builder.HasOne(transactionCategory => transactionCategory.User)
            //    .WithOne()
            //    .HasForeignKey<TransactionCategory>("UserId");
        }
    }
}
