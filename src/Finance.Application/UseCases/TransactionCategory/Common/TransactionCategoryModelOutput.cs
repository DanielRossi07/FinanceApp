using DomainEntity = Finance.Domain.Entity;

namespace Finance.Application.UseCases.TransactionCategory.Common
{
    public class TransactionCategoryModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionCategoryModelOutput(Guid id, string name, string description, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static TransactionCategoryModelOutput FromCategory(DomainEntity.TransactionCategory transactionCategory)
        => new(
            transactionCategory.Id,
            transactionCategory.Name,
            transactionCategory.Description,
            transactionCategory.UserId,
            transactionCategory.CreatedAt
        );
    }
}
