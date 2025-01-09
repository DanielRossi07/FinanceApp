using Finance.Application.UseCases.TransactionSource.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public class DeleteTransactionSourceInput : IRequest<TransactionSourceModelOutput>
    {
        public Guid Id { get; set; }

        public DeleteTransactionSourceInput(Guid id)
        {
            Id = id;
        }
    }
}
