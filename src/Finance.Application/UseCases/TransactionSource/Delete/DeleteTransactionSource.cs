using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.TransactionSource
{
    public class DeleteTransactionSource : IDeleteTransactionSource
    {
        private readonly ITransactionSourceRepository _transactionSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransactionSource(ITransactionSourceRepository transactionSourceRepository, IUnitOfWork unitOfWork)
        {
            _transactionSourceRepository = transactionSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionSourceModelOutput> Handle(DeleteTransactionSourceInput input, CancellationToken cancellationToken)
        {
            var transactionSource = await _transactionSourceRepository.Get(input.Id, cancellationToken);
            await _transactionSourceRepository.Delete(transactionSource, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
