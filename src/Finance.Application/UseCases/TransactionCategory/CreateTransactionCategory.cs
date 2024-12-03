using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionCategory.Common;
using Finance.Domain.Repository;
using DomainEntity = Finance.Domain.Entity;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class CreateTransactionCategory : ICreateTransactionCategory
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransactionCategory(ITransactionCategoryRepository transactionCategoryRepository, IUnitOfWork unitOfWork)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionCategoryModelOutput> Handle(CreateTransactionCategoryInput input, CancellationToken cancellationToken)
        {
            var transactionCategory = new DomainEntity.TransactionCategory(
                input.Name, 
                input.Description, 
                input.UserId);

            await _transactionCategoryRepository.Insert(transactionCategory, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionCategoryModelOutput.FromCategory(transactionCategory);
        }
    }
}
