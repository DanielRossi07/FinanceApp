using Finance.Application.UseCases.BankAccount.Common;
using MediatR;

namespace Finance.Application.UseCases.BankAccount
{
    public class UpdateBankAccountInput : IRequest<BankAccountModelOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UpdateBankAccountInput(Guid id, string name)
        {
            Id = id;
            Name = name;
            UpdatedAt = DateTime.Now; // Should this be responsibility of application layer? This should be validated in the domain layer, But I'm not sure where it should be applied
        }
    }
}
