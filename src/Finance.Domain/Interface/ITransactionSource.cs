using Finance.Domain.Entity;

namespace Finance.Domain.Interface
{
    public interface ITransactionSource : IEntity
    {
        public string Name { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
