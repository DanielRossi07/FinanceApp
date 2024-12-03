using Xunit;
using FluentAssertions;
using DomainEntity = Finance.Domain.Entity;
using DomainException = Finance.Domain.Exceptions;

namespace Finance.UnitTests.Domain.Entity.TransactionCategory
{
    public class TransactionCategoryTest
    {
        [Fact(DisplayName = nameof(Instantiate))]
        [Trait("Domain", "TransactionCategory")]
        public void Instantiate()
        {
            var validTransactionCategory = GetCategory();

            validTransactionCategory.Should().NotBeNull();
            validTransactionCategory.Id.Should().NotBeEmpty();
            validTransactionCategory.Name.Should().Be("Uber");
            validTransactionCategory.Description.Should().Be("Todos os gastos com aplicativos de transporte");
            validTransactionCategory.UserId.Should().Be(validTransactionCategory.Id);
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsNull))]
        [Trait("Domain", "TransactionCategory")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void InstantiateErrorWhenNameIsNull(string? name)
        {
            var validTransactionCategory = GetCategory();

            Action action = 
                () => new DomainEntity.TransactionCategory(name!, validTransactionCategory.Description, validTransactionCategory.UserId);

            action.Should()
                .Throw<DomainException.EntityValidationException>()
                .WithMessage("Name should not be null");
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsLesserThan2Characters))]
        [Trait("Domain", "TransactionCategory")]
        [MemberData(nameof(GetNamesWithXCharacters), parameters: 10)]
        public void InstantiateErrorWhenNameIsLesserThan2Characters(string? name)
        {
            var validTransactionCategory = GetCategory();

            Action action =
                () => new DomainEntity.TransactionCategory(name!, validTransactionCategory.Description, validTransactionCategory.UserId);

            action.Should()
                .Throw<DomainException.EntityValidationException>()
                .WithMessage("Name should be at least 2 characters long");
        }

        public static IEnumerable<object[]> GetNamesWithXCharacters(int numberOfTests = 6)
        {
            //TODO: Function should receive numberOfCharacters to be returned
            var fixture = new TransactionCategoryTestFixture();
            for (int i = 0; i < numberOfTests; i++)
            {
                yield return new object[] {
                    fixture.GetValidTransactionCategoryName()[0]
                };
            }
        }

        [Fact(DisplayName = nameof(InstantiateErrorWhenNameIsGreaterThan50Characters))]
        [Trait("Domain", "TransactionCategory")]
        public void InstantiateErrorWhenNameIsGreaterThan50Characters()
        {
            var validTransactionCategory = GetCategory();
            var invalidName = String.Join(null, Enumerable.Range(1, 51).Select(_ => "a").ToArray());

            Action action =
                () => new DomainEntity.TransactionCategory(invalidName, validTransactionCategory.Description, validTransactionCategory.UserId);

            action.Should()
                .Throw<DomainException.EntityValidationException>()
                .WithMessage("Name should be less or equal 50 characters long");
        }


        private DomainEntity.TransactionCategory GetCategory()
        {
            return new DomainEntity.TransactionCategory("Uber", "Todos os gastos com aplicativos de transporte", Guid.NewGuid());
        }
    }
}
