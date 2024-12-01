namespace Finance.Domain.Entity
{
    public class InstallmentPlan : SeedWork.Entity
    {
        public string Name { get; set; }
        public DateTime InitialDate { get; set; }
        public int NumberOfInstallments { get; set; }
        public List<Transaction> Transactions { get; set; }
        public DateTime EndDate 
        {
            get { return InitialDate.AddMonths(NumberOfInstallments); }
        }

        public InstallmentPlan(string name, DateTime initialDate, int numberOfInstallments, List<Transaction> transactions, Guid userId) : base(userId)
        {
            Name = name;
            InitialDate = initialDate;
            NumberOfInstallments = numberOfInstallments;
            Transactions = transactions;

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
