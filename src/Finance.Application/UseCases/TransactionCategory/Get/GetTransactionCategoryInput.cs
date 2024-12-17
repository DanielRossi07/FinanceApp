using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class GetTransactionCategoryInput : IRequest<TransactionCategoryModelOutput>
    {
        public Guid Id { get; set; }

        public GetTransactionCategoryInput(Guid id)
        {
            Id = id;
        }
    }
}
