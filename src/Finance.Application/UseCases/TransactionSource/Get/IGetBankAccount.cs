﻿using Finance.Application.UseCases.BankAccount.Common;
using MediatR;

namespace Finance.Application.UseCases.BankAccount
{
    public interface IGetBankAccount : IRequestHandler<GetBankAccountInput, BankAccountModelOutput>
    { }
}
