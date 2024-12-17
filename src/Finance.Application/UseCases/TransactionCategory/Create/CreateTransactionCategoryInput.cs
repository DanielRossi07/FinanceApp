using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class CreateTransactionCategoryInput : IRequest<TransactionCategoryModelOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public CreateTransactionCategoryInput(Guid id, string name, string description, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}
