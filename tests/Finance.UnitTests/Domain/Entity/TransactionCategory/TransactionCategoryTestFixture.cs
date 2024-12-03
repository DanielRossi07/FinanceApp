using Bogus;
using Finance.UnitTests.Common;
using Xunit;
using DomainEntity = Finance.Domain.Entity;

namespace Finance.UnitTests.Domain.Entity.TransactionCategory
{
    public class TransactionCategoryTestFixture : BaseFixture
    {
        public TransactionCategoryTestFixture()
            : base() { }

        public string GetValidTransactionCategoryName()
        {
            var categoryName = "";
            while (categoryName.Length < 2)
                categoryName = Faker.Commerce.Categories(1)[0];
            if (categoryName.Length > 50)
                categoryName = categoryName[..50];
            return categoryName;
        }

        public string GetValidTransactionCategoryDescription()
        {
            var categoryDescription =
                Faker.Commerce.ProductDescription();
            if (categoryDescription.Length > 255)
                categoryDescription =
                    categoryDescription[..255];
            return categoryDescription;
        }

        public Guid GetValidTransactionCategoryId()
        {
            return Guid.NewGuid();
        }

        public DomainEntity.TransactionCategory GetValidTransactionCategory()
            => new(
                GetValidTransactionCategoryName(),
                GetValidTransactionCategoryDescription(),
                GetValidTransactionCategoryId()
            );
    }

    [CollectionDefinition(nameof(TransactionCategoryTestFixture))]
    public class TransactionCategoryTestFixtureCollection
        : ICollectionFixture<TransactionCategoryTestFixture>
    { }
}