﻿using Finance.Domain.Enum;
using Finance.Domain.SeedWork;

namespace Finance.Domain.Entity
{
    public class Billet : TransactionSource
    {
        public Billet(string name, Guid bankAccountId, Guid userId) : base(name, bankAccountId, TransactionSourceType.Billet, userId)
        {
            Validate();
        }

        public override void Update(string name, Guid bankAccountId)
        {
            Name = name;
            BankAccountId = bankAccountId;

            Validate();
        }

        public override void UpdateFromSource(TransactionSource input)
        {
            Id = input.Id;
            Update(input.Name, input.BankAccountId);
        }

        public override void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 2, nameof(Name));
            DomainValidation.MaxLength(Name, 50, nameof(Name));
        }
    }
}
