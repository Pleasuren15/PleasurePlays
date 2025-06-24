using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

var builder = CoconaApp.CreateBuilder();
builder.Logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
builder.Services.AddHttpClient();

var app = builder.Build();

app.AddCommand("joker", async (IHttpClientFactory httpClientFactory) =>
{
    var jokeUrl = "https://v2.jokeapi.dev/joke/Dark?type=single";
    var client = httpClientFactory.CreateClient();
    var response = await client.GetStringAsync(jokeUrl);
    Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
});

app.Run();