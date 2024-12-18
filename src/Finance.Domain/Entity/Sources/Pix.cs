using Finance.Domain.Enum;
using Finance.Domain.SeedWork;

namespace Finance.Domain.Entity
{
    public class Pix : TransactionSource
    {
        public Pix(string name, Guid bankAccountId, Guid userId) : base(name, bankAccountId, TransactionSourceType.Pix, userId)
        {
            Validate();
        }

        public override void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));
        }
    }
}
