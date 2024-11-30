namespace Finance.Domain.Entity
{
    public class SavingGoal : SeedWork.Entity
    {
        #region mapped properties
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ExpectedTotalValue { get; set; }
        public decimal ExpectedMonthlyValue { get; set; }
        public decimal CurrentSavedValue { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public TransactionCategory Category { get; set; }
        #endregion

        #region NotMapped
        // TODO: Implement unit test for these properties
        public int MonthsToEnd 
        {
            get 
            { 
                return ((EndDate.Year - DateTime.Now.Year) * 12) + EndDate.Month - DateTime.Now.Month; 
            }
        }

        public decimal CurrentNeededMonthlyValue
        {
            get 
            {
                return (ExpectedTotalValue - CurrentSavedValue) / MonthsToEnd;
            }
        }

        public decimal CurrentNeededTotalValue
        {
            get
            {
                return ExpectedTotalValue - CurrentSavedValue;
            }
        }
        #endregion

        public SavingGoal(
            string name, 
            string description, 
            decimal expectedTotalValue,
            decimal expectedMonthlyValue, 
            DateTime initialDate, 
            DateTime endDate, 
            TransactionCategory transactionCategory, 
            Guid userId
            ) : base(userId)
        {
            Name = name;
            Description = description;
            ExpectedTotalValue = expectedTotalValue;
            ExpectedMonthlyValue = expectedMonthlyValue;
            InitialDate = initialDate;
            EndDate = endDate;
            Category = transactionCategory;

            Validate();
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));

            // TODO: Implement validation to other properties
        }
    }
}
