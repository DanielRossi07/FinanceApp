using Finance.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.EF.Configurations
{
    internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");

            builder.HasKey(bankAccount => bankAccount.Id);

            // Navigation
            //builder.Navigation(bankAccount => bankAccount.User).AutoInclude();

            // Relationships
            //builder.HasOne(bankAccount => bankAccount.User)
            //    .WithOne()
            //    .HasForeignKey<BankAccount>("UserId");
        }
    }
}
