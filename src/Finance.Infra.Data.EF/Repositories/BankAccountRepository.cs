using Finance.Application.Exceptions;
using Finance.Domain.Entity;
using Finance.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.EF.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly FinanceDbContext _context;
        private DbSet<BankAccount> _bankAccounts => _context.Set<BankAccount>();

        public BankAccountRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task Insert(BankAccount aggregate, CancellationToken cancellationToken)
        {
            await _bankAccounts.AddAsync(aggregate, cancellationToken);
        }
        public async Task<BankAccount> Get(Guid id, CancellationToken cancellationToken)
        {
            var category = await _bankAccounts.FindAsync(new object[] { id }, cancellationToken);
            NotFoundException.ThrowIfNull(category, $"BankAccount '{id}' not found.");

            return category!;
        }

        public Task Update(BankAccount aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_bankAccounts.Update(aggregate));
        }

        public Task Delete(BankAccount aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_bankAccounts.Remove(aggregate));
        }
    }
}
