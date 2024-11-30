using Finance.Domain.Interface;

namespace Finance.Domain.Entity
{
    public class Billet : SeedWork.Entity, ITransactionSource
    {
        public string Name { get; set; }
        public BankAccount BankAccount { get; set; }

        public Billet(string name, BankAccount bankAccount, Guid userId) : base(userId)
        {
            Name = name;
            BankAccount = bankAccount;

            Validate();
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));
        }
    }
}
