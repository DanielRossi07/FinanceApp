using DomainEntity = Finance.Domain.Entity;

namespace Finance.Application.UseCases.BankAccount.Common
{
    public class BankAccountModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public BankAccountModelOutput(Guid id, string name, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static BankAccountModelOutput FromBankAccount(DomainEntity.BankAccount bankAccount)
        => new(
            bankAccount.Id,
            bankAccount.Name,
            bankAccount.UserId,
            bankAccount.CreatedAt
        );
    }
}
