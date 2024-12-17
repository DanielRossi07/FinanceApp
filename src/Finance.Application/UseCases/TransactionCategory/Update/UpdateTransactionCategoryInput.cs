using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;

namespace Finance.Application.UseCases.TransactionCategory
{
    public class UpdateTransactionCategoryInput : IRequest<TransactionCategoryModelOutput>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UpdateTransactionCategoryInput(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now; // Should this be responsibility of application layer? This should be validated in the domain layer, But I'm not sure where it should be applied
        }
    }
}
