using Finance.Domain.Entity;
using Finance.Domain.Enum;
using Finance.Domain.SeedWork;

namespace Finance.Domain.Interface
{
    public interface ITransaction : IEntity
    {
        string Description { get; set; }
        decimal Value { get; set; }
        TransactionType Type { get; set; }
        TransactionSourceType? SourceType { get; set; }
        TransactionSource? Source { get; set; }
        TransactionCategory? Category { get; set; }
    }
}
