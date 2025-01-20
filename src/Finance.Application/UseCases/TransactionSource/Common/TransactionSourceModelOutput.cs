using Finance.Domain.Enum;
using DomainSeedWork = Finance.Domain.SeedWork;

namespace Finance.Application.UseCases.TransactionSource.Common
{
    public class TransactionSourceModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TransactionSourceType Type { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionSourceModelOutput(Guid id, string name, TransactionSourceType type, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Type = type;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static TransactionSourceModelOutput FromTransactionSource(DomainSeedWork.TransactionSource transactionSource)
        => new(
            transactionSource.Id,
            transactionSource.Name,
            transactionSource.Type,
            transactionSource.UserId,
            transactionSource.CreatedAt
        );
    }
}
