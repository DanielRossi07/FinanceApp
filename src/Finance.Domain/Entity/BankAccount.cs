namespace Finance.Domain.Entity
{
    public class BankAccount : SeedWork.Entity
    {
        public string Name { get; set; }

        public BankAccount(string name, Guid userId) : base(userId)
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
