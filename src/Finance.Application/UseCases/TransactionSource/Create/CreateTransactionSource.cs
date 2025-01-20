using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;

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
            var transactionSource = new TransactionSourceFactory().Create(input);

            await _transactionSourceRepository.Insert(transactionSource, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
