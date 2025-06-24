using Cocona;
using CustomCLI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

var builder = CoconaApp.CreateBuilder();
builder.Logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
builder.Services.AddHttpClient();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("CustomCLI");

var app = builder.Build();

app.AddCommand("joker", async (IHttpClientFactory httpClientFactory) =>
{
    logger.LogInformation("Get Joke Start: Time {0}", DateTime.UtcNow);

    var jokeUrl = builder.Configuration["JokerApiUrl"]; ;
    var client = httpClientFactory.CreateClient();
    var response = await client.GetStringAsync(jokeUrl);
    var actualResponse = JsonSerializer.Deserialize<JokeResponse>(response, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    Console.WriteLine(JsonSerializer.Serialize(actualResponse, new JsonSerializerOptions { WriteIndented = true }));
    logger.LogInformation("Get Joke End: Time {0}", DateTime.UtcNow);
});

app.Run();