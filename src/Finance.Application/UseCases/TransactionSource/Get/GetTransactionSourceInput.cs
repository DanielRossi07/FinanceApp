using Finance.Application.UseCases.TransactionSource.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public class GetTransactionSourceInput : IRequest<TransactionSourceModelOutput>
    {
        public Guid Id { get; set; }

        public GetTransactionSourceInput(Guid id)
        {
            Id = id;
        }
    }
}
