using Finance.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppConnections()
    .AddUseCases()
    .AddAndConfigureControllers();

var app = builder.Build();
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
