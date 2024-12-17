using Finance.Application.UseCases.BankAccount.Common;
using MediatR;

namespace Finance.Application.UseCases.BankAccount
{
    public class CreateBankAccountInput : IRequest<BankAccountModelOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public CreateBankAccountInput(Guid id, string name, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}
