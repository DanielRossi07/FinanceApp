using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public interface IUpdateTransactionCategory : IRequestHandler<UpdateTransactionCategoryInput, TransactionCategoryModelOutput>
    { }
}
