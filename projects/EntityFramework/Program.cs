using EntityFramework.Infrastructure;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionStrings:PleasurePlaysDatabase"]);

        var app = builder.Build();
        await app.RunAsync();
    }
}