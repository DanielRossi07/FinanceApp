using Finance.Application.UseCases.TransactionSource.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public interface IDeleteTransactionSource : IRequestHandler<DeleteTransactionSourceInput, TransactionSourceModelOutput>
    { }
}
