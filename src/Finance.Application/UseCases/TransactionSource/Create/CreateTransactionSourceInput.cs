using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Enum;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public class CreateTransactionSourceInput : ITransactionSourceFactoryModel, IRequest<TransactionSourceModelOutput>
    {
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
