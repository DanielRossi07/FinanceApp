using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionCategory.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class DeleteTransactionCategory : IDeleteTransactionCategory
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransactionCategory(ITransactionCategoryRepository transactionCategoryRepository, IUnitOfWork unitOfWork)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionCategoryModelOutput> Handle(DeleteTransactionCategoryInput input, CancellationToken cancellationToken)
        {
            var transactionCategory = await _transactionCategoryRepository.Get(input.Id, cancellationToken);
            await _transactionCategoryRepository.Delete(transactionCategory, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionCategoryModelOutput.FromCategory(transactionCategory);
        }
    }
}
