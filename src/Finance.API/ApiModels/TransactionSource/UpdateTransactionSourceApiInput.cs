using Finance.Domain.Enum;

namespace Finance.API.ApiModels.TransactionSource
{
    public class UpdateTransactionSourceApiInput
    {
        public string Name { get; set; }
        public Guid BankAccountId { get; set; }
        public TransactionSourceType Type { get; set; }

        public UpdateTransactionSourceApiInput(string name, Guid bankAccountId, TransactionSourceType type)
        {
            Name = name;
            BankAccountId = bankAccountId;
            Type = type;
        }
    }
}
