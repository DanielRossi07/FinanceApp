using Finance.Application.UseCases.BankAccount.Common;
using MediatR;

namespace Finance.Application.UseCases.BankAccount
{
    public class DeleteBankAccountInput : IRequest<BankAccountModelOutput>
    {
        public Guid Id { get; set; }

        public DeleteBankAccountInput(Guid id)
        {
            Id = id;
        }
    }
}
