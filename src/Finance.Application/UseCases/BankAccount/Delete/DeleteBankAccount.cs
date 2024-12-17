using Finance.Application.Interfaces;
using Finance.Application.UseCases.BankAccount.Common;
using Finance.Domain.Repository;

namespace Finance.Application.UseCases.BankAccount
{
    public class DeleteBankAccount : IDeleteBankAccount
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankAccount(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BankAccountModelOutput> Handle(DeleteBankAccountInput input, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountRepository.Get(input.Id, cancellationToken);
            await _bankAccountRepository.Delete(bankAccount, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return BankAccountModelOutput.FromBankAccount(bankAccount);
        }
    }
}
