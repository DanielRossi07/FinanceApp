using Finance.Application.UseCases.BankAccount.Common;
using MediatR;

namespace Finance.Application.UseCases.BankAccount
{
    public class GetBankAccountInput : IRequest<BankAccountModelOutput>
    {
        public Guid Id { get; set; }

        public GetBankAccountInput(Guid id)
        {
            Id = id;
        }
    }
}
