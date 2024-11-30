namespace Finance.Domain.Entity
{
    public class TransactionCategory : SeedWork.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public TransactionCategory(string name, string description, Guid userId) : base(userId)
        {
            Name = name;
            Description = description;

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
