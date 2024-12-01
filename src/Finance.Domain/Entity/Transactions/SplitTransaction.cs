using Finance.Domain.Enum;
using Finance.Domain.Interface;

namespace Finance.Domain.Entity
{
    public class SplitTransaction : SeedWork.Entity, IInstallmentTransaction, IRecurrentTransaction
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public TransactionSourceType? SourceType { get; set; }
        public ITransactionSource? Source { get; set; }
        public TransactionCategory? Category { get; set; }
        public InstallmentPlan? InstallmentPlan { get; set; }
        public Transaction ParentTransaction { get; set; }

        public RecurrentTransaction RecurrentTransaction { get; set; }

        public SplitTransaction(
            string description, 
            decimal value, 
            TransactionType type, 
            TransactionSourceType sourceType, 
            ITransactionSource source,
            TransactionCategory category,
            InstallmentPlan installmentPlan,
            RecurrentTransaction recurrentTransaction,
            Transaction parentTransaction,
            Guid userId)
            : base(userId)
        {
            Description = description;
            Value = value;
            Type = type;
            SourceType = sourceType;
            Source = source;
            Category = category;
            InstallmentPlan = installmentPlan;
            RecurrentTransaction = recurrentTransaction;
            ParentTransaction = parentTransaction;

            Validate();
        }

        public override void Validate()
        {
            // Implement
        }
    }
}
