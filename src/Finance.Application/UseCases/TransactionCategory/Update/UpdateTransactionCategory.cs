﻿using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionCategory.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class UpdateTransactionCategory : IUpdateTransactionCategory
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTransactionCategory(ITransactionCategoryRepository transactionCategoryRepository, IUnitOfWork unitOfWork)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionCategoryModelOutput> Handle(UpdateTransactionCategoryInput input, CancellationToken cancellationToken)
        {
            var transactionCategory = await _transactionCategoryRepository.Get(input.Id, cancellationToken);
            transactionCategory.Update(input.Name, input.Description);

            await _transactionCategoryRepository.Update(transactionCategory, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return TransactionCategoryModelOutput.FromCategory(transactionCategory);
        }
    }
}