using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Repository;
using SeedWork = Finance.Domain.SeedWork;

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
            
            // Should I delete the transaction source and create a new one instead of updating it?
            // Should I change the way I initialize the TransactionSource? 
            // How to deal with optional properties, how do I know if the user actually removed a property or just did not send the property?

            SeedWork.TransactionSource newTransactionSource;
            if (transactionSource.Type != input.Type)
            {
                newTransactionSource = new TransactionSourceFactory().Create(input);
                newTransactionSource.UseIdFromOldSource(transactionSource);
                await _transactionSourceRepository.Delete(transactionSource, cancellationToken);
                await _transactionSourceRepository.Insert(newTransactionSource, cancellationToken);
            }
            else
            {
                transactionSource.Update(input.Name, input.BankAccountId);
                await _transactionSourceRepository.Update(transactionSource, cancellationToken);
            }
            
            await _unitOfWork.Commit(cancellationToken);

            return TransactionSourceModelOutput.FromTransactionSource(transactionSource);
        }
    }
}
