using Finance.Application.Interfaces;
using Finance.Application.UseCases.BankAccount.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.BankAccount
{
    public class UpdateBankAccount : IUpdateBankAccount
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankAccount(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BankAccountModelOutput> Handle(UpdateBankAccountInput input, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountRepository.Get(input.Id, cancellationToken);
            bankAccount.Update(input.Name);

            await _bankAccountRepository.Update(bankAccount, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return BankAccountModelOutput.FromBankAccount(bankAccount);
        }
    }
}
