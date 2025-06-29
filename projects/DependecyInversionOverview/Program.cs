using Cocona;
using DependecyInversionOverview.Models;
using DependecyInversionOverview.Models.Implementation;
using DependecyInversionOverview.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConsoleTables;

var builder = CoconaApp.CreateBuilder();
builder.Logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddSingleton<IScopedService, ScopedService>();

var app = builder.Build();

app.AddCommand("singletonServiceOverview", () =>
{
    Console.WriteLine("🔄 Transient a new instance is created every time the service is requested.");
    Console.WriteLine("♻️ Scoped one instance per request (or per scope).\n\t\t The same instance is used throughout a single HTTP request, but a new one is created for each new request.");
    Console.WriteLine("♾️ Singleton one instance for the entire application lifetime. Shared across all requests and users.");

    var table = new ConsoleTable("Name", "InstanceId");
    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        (var name, var instanceId) = testController.TestSingletonService();
        table.AddRow(name, instanceId);
    }

    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        (var name, var instanceId) = testController.TestScopedService();
        table.AddRow(name, instanceId);
    }

    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        (var name, var instanceId) = testController.TestTransientService();
        table.AddRow(name, instanceId);
    }

    table.Write();
});


app.Run();