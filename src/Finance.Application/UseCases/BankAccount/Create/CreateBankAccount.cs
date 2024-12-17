using Finance.Application.Interfaces;
using Finance.Application.UseCases.BankAccount.Common;
using Finance.Domain.Repository;
using DomainEntity = Finance.Domain.Entity;

namespace Finance.Application.UseCases.BankAccount
{
    public class BankAccount : ICreateBankAccount
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BankAccount(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BankAccountModelOutput> Handle(CreateBankAccountInput input, CancellationToken cancellationToken)
        {
            var bankAccount = new DomainEntity.BankAccount(
                input.Name, 
                input.UserId);

            await _bankAccountRepository.Insert(bankAccount, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return BankAccountModelOutput.FromBankAccount(bankAccount);
        }
    }
}
