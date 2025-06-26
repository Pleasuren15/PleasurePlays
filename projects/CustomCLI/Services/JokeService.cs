using CustomCLI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CustomCLI.Services
{
    /// <inheritdoc/>
    internal class JokeService(IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        ILogger<JokeService> logger) : IJokeService
    {
        IHttpClientFactory _httpClientFactory = httpClientFactory;
        IConfiguration _configuration = configuration;
        ILogger<JokeService> _logger = logger;

        /// <inheritdoc/>
        public async Task<JokeResponse> GetRandomJokeAsync()
        {
            try
            {
                _logger.LogInformation("GetRandomJoke Start: Time {time}", DateTime.Now);

                var jokeUrl = _configuration["JokerApiUrl"];
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetStringAsync(jokeUrl);
                var actualResponse = JsonSerializer.Deserialize<JokeResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Console.WriteLine(JsonSerializer.Serialize(actualResponse, new JsonSerializerOptions { WriteIndented = true }));
                return actualResponse!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("An error occurred while fetching the joke.");
            }
            finally
            {
                _logger.LogInformation("GetRandomJoke End: Time {time}", DateTime.Now);
            }
        }
    }
}
