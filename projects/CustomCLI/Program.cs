using Cocona;
using CustomCLI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();
builder.Logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IJokeService, JokeService>();
builder.Services.AddScoped<IInfobioService, InfobioService>();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("CustomCLI");

var app = builder.Build();

app.AddCommand("sendJokeToRecipient", async (IInfobioService _infobioService) =>
{
    logger.LogInformation("Get Joke Start: Time {0}", DateTime.UtcNow);

    await _infobioService.SendJokeToRecipientAsync();

    logger.LogInformation("Get Joke End: Time {0}", DateTime.UtcNow);
});

app.Run();