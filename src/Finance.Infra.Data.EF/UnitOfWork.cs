﻿using Finance.Application.Interfaces;

namespace Finance.Infra.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceDbContext _context;

        public UnitOfWork(FinanceDbContext context)
        {
            _context = context;
        }

        public Task Commit(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
