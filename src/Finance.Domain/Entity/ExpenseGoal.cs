namespace Finance.Domain.Entity
{
    public class ExpenseGoal : SeedWork.Entity
    {
        #region mapped properties
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public TransactionCategory Category { get; set; }
        #endregion

        public ExpenseGoal(
            string name, 
            string description, 
            decimal value,
            TransactionCategory transactionCategory, 
            Guid userId
            ) : base(userId)
        {
            Name = name;
            Description = description;
            Value = value;
            Category = transactionCategory;

            Validate();
        }

        public override void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));

            // TODO: Implement validation to other properties
        }
    }
}
