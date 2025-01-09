using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.TransactionSource
{
    public class UpdateTransactionSource : IUpdateTransactionSource
    {
        private readonly ITransactionSourceRepository _transactionSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTransactionSource(ITransactionSourceRepository transactionSourceRepository, IUnitOfWork unitOfWork)
        {
            _transactionSourceRepository = transactionSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionSourceModelOutput> Handle(UpdateTransactionSourceInput input, CancellationToken cancellationToken)
        {
            var transactionSource = await _transactionSourceRepository.Get(input.Id, cancellationToken);
            transactionSource.Update(input.Name, input.BankAccountId, input.Type);

            await _transactionSourceRepository.Update(transactionSource, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
