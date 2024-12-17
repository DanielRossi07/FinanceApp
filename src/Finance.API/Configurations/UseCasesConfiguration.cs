using Finance.Application.Interfaces;
using Finance.Application.UseCases.TransactionCategory;
using Finance.Domain.Repository;
using Finance.Infra.Data.EF;
using Finance.Infra.Data.EF.Repositories;

namespace Finance.API.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<CreateTransactionCategory>());
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITransactionCategoryRepository, TransactionCategoryRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
