using Finance.Domain.Enum;

namespace Finance.Application.UseCases.TransactionSource.Common
{
    public class ITransactionSourceFactoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BankAccountId { get; set; }
        public TransactionSourceType Type { get; set; }
        public Guid UserId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
