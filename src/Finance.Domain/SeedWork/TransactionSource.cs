using Finance.Domain.Entity;
using Finance.Domain.Enum;

namespace Finance.Domain.SeedWork
{
    public abstract class TransactionSource : AggregateRoot
    {
        public string Name { get; protected set; }
        public Guid BankAccountId { get; protected set; }
        public BankAccount? BankAccount { get; protected set; }
        public TransactionSourceType Type { get; protected set; }

        protected TransactionSource(string name, Guid bankAccountId, TransactionSourceType type, Guid userId) : base(userId)
        {
            Name = name;
            BankAccountId = bankAccountId;
            Type = type;
        }

        public abstract void Update(string name, Guid bankAccountId);
    }
}
