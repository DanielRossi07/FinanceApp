using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public interface IDeleteTransactionCategory : IRequestHandler<DeleteTransactionCategoryInput, TransactionCategoryModelOutput>
    { }
}
