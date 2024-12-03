using Finance.Domain.Interface;
using Finance.Domain.SeedWork;

namespace Finance.Domain.Entity
{
    public class Pix : AggregateRoot, ITransactionSource
    {
        public string Name { get; set; }
        public BankAccount BankAccount { get; set; }

        public Pix(string name, BankAccount bankAccount, Guid userId) : base(userId)
        {
            Name = name;
            BankAccount = bankAccount;

            Validate();
        }

        public override void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));
        }
    }
}
