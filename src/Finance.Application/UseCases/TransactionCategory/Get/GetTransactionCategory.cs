using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionCategory.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class GetTransactionCategory : IGetTransactionCategory
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetTransactionCategory(ITransactionCategoryRepository transactionCategoryRepository, IUnitOfWork unitOfWork)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionCategoryModelOutput> Handle(GetTransactionCategoryInput input, CancellationToken cancellationToken)
        {
            var transactionCategory = await _transactionCategoryRepository.Get(input.Id, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionCategoryModelOutput.FromCategory(transactionCategory);
        }
    }
}
