using Cocona;
using DependecyInversionOverview.Models;
using DependecyInversionOverview.Models.Implementation;
using DependecyInversionOverview.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


var builder = CoconaApp.CreateBuilder();
builder.Logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddSingleton<IScopedService, ScopedService>();

var app = builder.Build();

app.AddCommand("singletonServiceOverview", () =>
{
    Console.WriteLine("Test Singleton LifeTime");
    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        testController.TestSingletonService();
    }

    Console.WriteLine("\n\nTest Scoped LifeTime");
    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        testController.TestScopedService();
    }

    Console.WriteLine("\n\nTest Transient LifeTime");
    for (int i = 0; i < 3; i++)
    {
        var testController = new TestController(
            app.Services.GetRequiredService<ISingletonService>(),
            app.Services.GetRequiredService<IScopedService>(),
            app.Services.GetRequiredService<ITransientService>());

        testController.TestTransientService();
    }
});


app.Run();