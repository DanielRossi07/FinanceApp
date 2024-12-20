using DomainSeedWork = Finance.Domain.SeedWork;

namespace Finance.Application.UseCases.TransactionSource.Common
{
    public class TransactionSourceModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionSourceModelOutput(Guid id, string name, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static TransactionSourceModelOutput FromTransactionSource(DomainSeedWork.TransactionSource bankAccount)
        => new(
            bankAccount.Id,
            bankAccount.Name,
            bankAccount.UserId,
            bankAccount.CreatedAt
        );
    }
}
