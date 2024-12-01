using Finance.Domain.Entity;
using Finance.Domain.Enum;

namespace Finance.Domain.Interface
{
    public interface ITransaction : IEntity
    {
        string Description { get; set; }
        decimal Value { get; set; }
        TransactionType Type { get; set; }
        TransactionSourceType? SourceType { get; set; }
        ITransactionSource? Source { get; set; }
        TransactionCategory? Category { get; set; }
    }
}
