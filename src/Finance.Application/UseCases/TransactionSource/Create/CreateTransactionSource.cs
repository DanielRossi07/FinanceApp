using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;
using DomainEntity = Finance.Domain.Entity;
using SeedWork = Finance.Domain.SeedWork;

namespace Finance.Application.UseCases.TransactionSource
{
    public class TransactionSource : ICreateTransactionSource
    {
        private readonly ITransactionSourceRepository _transactionSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionSource(ITransactionSourceRepository transactionSourceRepository, IUnitOfWork unitOfWork)
        {
            _transactionSourceRepository = transactionSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionSourceModelOutput> Handle(CreateTransactionSourceInput input, CancellationToken cancellationToken)
        {
            // TODO: Change initialization to: strategy pattern. Maybe add reflection to use the constructor instead of adding a Create method
            SeedWork.TransactionSource transactionSource;
            switch (input.Type)
            {
                case Domain.Enum.TransactionSourceType.Billet:
                    transactionSource = new DomainEntity.Billet(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case Domain.Enum.TransactionSourceType.Card:
                    transactionSource = new DomainEntity.Card(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case Domain.Enum.TransactionSourceType.Transfer:
                    transactionSource = new DomainEntity.Transfer(
                    input.Name,
                    input.BankAccountId,
                    input.UserId);
                    break;
                case Domain.Enum.TransactionSourceType.Pix:
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

            await _transactionSourceRepository.Insert(transactionSource, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
