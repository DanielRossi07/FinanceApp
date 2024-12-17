using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class DeleteTransactionCategoryInput : IRequest<TransactionCategoryModelOutput>
    {
        public Guid Id { get; set; }

        public DeleteTransactionCategoryInput(Guid id)
        {
            Id = id;
        }
    }
}
