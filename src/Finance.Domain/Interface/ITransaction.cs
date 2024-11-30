using Finance.Domain.Entity;

namespace Finance.Domain.Interface
{
    public interface ITransaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BankAccount BankAccount { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
