namespace Finance.API.ApiModels.BankAccount
{
    public class UpdateBankAccountApiInput
    {
        public string Name { get; set; }

        public UpdateBankAccountApiInput(string name)
        {
            Name = name;
        }
    }
}
