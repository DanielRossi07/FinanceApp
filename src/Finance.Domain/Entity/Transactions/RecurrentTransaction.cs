using Finance.Domain.Enum;
using Finance.Domain.Interface;
using Finance.Domain.SeedWork;

namespace Finance.Domain.Entity
{
    public class RecurrentTransaction : SeedWork.Entity, ISplitTransaction
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public TransactionSourceType? SourceType { get; set; }
        public TransactionSource? Source { get; set; }
        public TransactionCategory? Category { get; set; }
        public List<SplitTransaction> SplitTransactions { get; set; }

        public RecurrentTransaction(
            string description, 
            decimal value, 
            TransactionType type, 
            TransactionSourceType sourceType,
            TransactionSource source,
            TransactionCategory category,
            List<SplitTransaction> splitTransactions,
            Guid userId)
            : base(userId)
        {
            Description = description;
            Value = value;
            Type = type;
            SourceType = sourceType;
            Source = source;
            Category = category;
            SplitTransactions = splitTransactions;

            Validate();
        }

        public override void Validate()
        {
            // Implement
        }
    }
}
