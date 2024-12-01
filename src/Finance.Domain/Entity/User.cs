namespace Finance.Domain.Entity
{
    public class User : SeedWork.Entity
    {
        public string Name { get; set; }
        public List<Transaction> Transactions => new List<Transaction>();
        public List<SavingGoal> SavingGoals => new List<SavingGoal>();
        public List<ExpenseGoal> ExpenseGoals => new List<ExpenseGoal>();
        public List<BankAccount> BankAccounts => new List<BankAccount>();
        public List<RecurrentTransaction> RecurrentTransactions => new List<RecurrentTransaction>();
        public List<SplitTransaction> SplitTransactions => new List<SplitTransaction>();
        public List<InstallmentPlan> InstallmentPlans => new List<InstallmentPlan>();

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
