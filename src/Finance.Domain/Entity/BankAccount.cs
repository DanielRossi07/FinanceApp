using Finance.Domain.SeedWork;

namespace Finance.Domain.Entity
{
    public class BankAccount : AggregateRoot
    {
        public string Name { get; set; }

        public BankAccount(string name, Guid userId) : base(userId)
        {
            Name = name;

            Validate();
        }

        public void Update(string name)
        {
            Name = name;

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
