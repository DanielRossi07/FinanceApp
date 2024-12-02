using Finance.Application.Exceptions;
using Finance.Domain.Entity;
using Finance.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.EF.Repositories
{
    internal class TransactionCategoryRepository : ITransactionCategoryRepository
    {
        private readonly FinanceDbContext _context;
        private DbSet<TransactionCategory> _categories => _context.Set<TransactionCategory>();

        public TransactionCategoryRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task Insert(TransactionCategory aggregate, CancellationToken cancellationToken)
        {
            await _categories.AddAsync(aggregate, cancellationToken);
        }
        public async Task<TransactionCategory> Get(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categories.FindAsync(new object[] { id }, cancellationToken);
            NotFoundException.ThrowIfNull(category, $"TransactionCategory '{id}' not found.");

            return category!;
        }

        public Task Update(TransactionCategory aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_categories.Update(aggregate));
        }

        public Task Delete(TransactionCategory aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_categories.Remove(aggregate));
        }
    }
}
