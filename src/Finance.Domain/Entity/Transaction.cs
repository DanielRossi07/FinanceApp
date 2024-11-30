using Finance.Domain.Enum;
using Finance.Domain.Interface;

namespace Finance.Domain.Entity
{
    public class Transaction : SeedWork.Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionSourceType? SourceType { get; set; }
        public ITransactionSource? Source { get; set; }
        public TransactionCategory? Category { get; set; }

        public Transaction(string description, Guid userId) : base(userId)
        {
            Description = description;

            Validate();
        }

        private void Validate()
        {
            // Implement
        }
    }
}
