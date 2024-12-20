using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;
using DomainEntity = Finance.Domain.Entity;

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
            // TODO: Define how to initialize transactions: If else, strategy pattern, reflection
            var transactionSource = new DomainEntity.Default(
                input.Name,
                input.BankAccountId,
                input.UserId);

            await _transactionSourceRepository.Insert(transactionSource, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
