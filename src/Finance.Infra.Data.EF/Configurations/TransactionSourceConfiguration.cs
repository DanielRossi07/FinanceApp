using Finance.Domain.Entity;
using Finance.Domain.Enum;
using Finance.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.EF.Configurations
{
    internal class TransactionSourceConfiguration : IEntityTypeConfiguration<TransactionSource>
    {
        public void Configure(EntityTypeBuilder<TransactionSource> builder)
        {
            // Map to a single table (Table-per-Hierarchy)
            builder.ToTable("TransactionSource");

            // Configure primary key
            builder.HasKey(ts => ts.Id);

            // Configure properties
            builder.Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ts => ts.BankAccountId)
                .IsRequired();

            builder.Property(ts => ts.Type)
                .HasConversion<string>() // Use string values for the enum in the database
                .IsRequired();

            builder.Property(ts => ts.UserId)
                .IsRequired();

            builder.Property(ts => ts.CreatedAt)
                .IsRequired();

            // Configure relationships
            builder.HasOne(ts => ts.BankAccount)
                .WithMany()
                .HasForeignKey(ts => ts.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Discriminator for TPH (Table-per-Hierarchy)
            builder.HasDiscriminator<TransactionSourceType>(ts => ts.Type)
                .HasValue<Transfer>(TransactionSourceType.Transfer)
                .HasValue<Pix>(TransactionSourceType.Pix)
                .HasValue<Billet>(TransactionSourceType.Billet)
                .HasValue<Card>(TransactionSourceType.Card);

        }
    }
}
