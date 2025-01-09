using Finance.Domain.Enum;
using DomainEntity = Finance.Domain.Entity;
using SeedWork = Finance.Domain.SeedWork;

namespace Finance.Application.UseCases.TransactionSource.Common
{
    public class TransactionSourceFactory
    {
        public SeedWork.TransactionSource Factory(CreateTransactionSourceInput input)
        {
            SeedWork.TransactionSource transactionSource;
            switch (input.Type)
            {
                case TransactionSourceType.Billet:
                    transactionSource = new DomainEntity.Billet(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case TransactionSourceType.Card:
                    transactionSource = new DomainEntity.Card(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case TransactionSourceType.Transfer:
                    transactionSource = new DomainEntity.Transfer(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case TransactionSourceType.Pix:
                    transactionSource = new DomainEntity.Pix(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                default:
                    transactionSource = new DomainEntity.Default(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
            }

            return transactionSource;
        }
    }
}
