using Finance.Application.UseCases.TransactionSource.Common;
using Finance.Domain.Entity;
using Finance.Domain.Enum;
using MediatR;

namespace Finance.Application.UseCases.TransactionSource
{
    public class UpdateTransactionSourceInput : ITransactionSourceFactoryModel, IRequest<TransactionSourceModelOutput>
    {

        public UpdateTransactionSourceInput(Guid id, string name, Guid bankAccountId, TransactionSourceType type)
        {
            Id = id;
            Name = name;
            BankAccountId = bankAccountId;
            Type = type;
            //UserId = Session.UserId -> Should I get the UserId in the controller or should I get it in here?
            UpdatedAt = DateTime.Now; // Should this be responsibility of application layer? This should be validated in the domain layer, But I'm not sure where it should be applied
        }
    }
}
