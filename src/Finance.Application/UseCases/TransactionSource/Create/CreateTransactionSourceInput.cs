using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Enum;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public class CreateTransactionSourceInput : IRequest<TransactionSourceModelOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BankAccountId { get; protected set; }
        public TransactionSourceType Type { get; protected set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public CreateTransactionSourceInput(Guid id, string name, Guid bankAccountId, TransactionSourceType type, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            BankAccountId = bankAccountId;
            Type = type;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}
