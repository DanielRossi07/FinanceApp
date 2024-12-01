namespace Finance.Domain.Entity
{
    public class User : SeedWork.Entity
    {
        public string Name { get; set; }
        public Credential Credential { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<SavingGoal> SavingGoals { get; set; }
        public List<ExpenseGoal> ExpenseGoals { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
        public List<RecurrentTransaction> RecurrentTransactions { get; set; }
        public List<SplitTransaction> SplitTransactions { get; set; }
        public List<InstallmentPlan> InstallmentPlans { get; set; }

        public User(string name, Guid userId) : base(userId)
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
