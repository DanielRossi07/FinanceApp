using Finance.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Configurations
{
    public static class ConnectionsConfiguration
    {
        public static IServiceCollection AddAppConnections(this IServiceCollection services)
        {
            services.AddDbConnection();
            return services;
        }

        private static IServiceCollection AddDbConnection(this IServiceCollection services)
        {
            services.AddDbContext<FinanceDbContext>(options => options.UseInMemoryDatabase("InMemory-DSV-Database"));
            return services;
        }
    }
}
