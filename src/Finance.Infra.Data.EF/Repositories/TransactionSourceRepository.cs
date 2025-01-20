using Finance.Application.Exceptions;
using Finance.Domain.Repository;
using Finance.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.EF.Repositories
{
    public class TransactionSourceRepository : ITransactionSourceRepository
    {
        private readonly FinanceDbContext _context;
        private DbSet<TransactionSource> _transactionSources => _context.Set<TransactionSource>();

        public TransactionSourceRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task Insert(TransactionSource aggregate, CancellationToken cancellationToken)
        {
            await _transactionSources.AddAsync(aggregate, cancellationToken);
        }

        public async Task<TransactionSource> Get(Guid id, CancellationToken cancellationToken)
        {
            var transactionSource = await _transactionSources.FindAsync(new object[] { id }, cancellationToken);
            NotFoundException.ThrowIfNull(transactionSource, $"TransactionSource '{id}' not found.");

            return transactionSource!;
        }

        public Task Update(TransactionSource aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_transactionSources.Update(aggregate));
        }

        public Task Delete(TransactionSource aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_transactionSources.Remove(aggregate));
        }
    }
}
