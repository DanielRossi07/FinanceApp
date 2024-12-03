using Finance.API.Filters;

namespace Finance.API.Configurations
{
    public static class ControllersConfigurations
    {
        public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddControllers(options => options.Filters.Add(typeof(ApiGlobalExceptionFilter)));
            services.AddDocumentation();

            return services;
        }

        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication UseDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
