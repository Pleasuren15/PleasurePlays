using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace CustomCLI.Services
{
    /// <summary>
    /// <inheritdoc cref="IInfobioService"/>/>
    /// </summary>
    internal class InfobioService(IJokeService jokeService , IConfiguration configuration,ILogger<InfobioService> logger) : IInfobioService
    {
        public IJokeService _jokeService { get; } = jokeService;
        public IConfiguration _configuration { get; } = configuration;
        public ILogger<InfobioService> _logger { get; } = logger;

        public Task SendJokeToRecipientEmailAsync()
        {
            try
            {
                _logger.LogInformation("SendJokeToRecipientEmailAsync Start: Time {time}", DateTime.UtcNow);

                return Task.FromResult("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("An error occurred while fetching the joke.");
            }
            finally
            {
                _logger.LogInformation("SendJokeToRecipientEmailAsync End: Time {time}", DateTime.UtcNow);
            }
        }

        public async Task SendJokeToRecipientSmsAsync()
        {
            try
            {
                _logger.LogInformation("SendJokeToRecipientSmsAsync Start: Time {time}", DateTime.UtcNow);
                var joke = await _jokeService.GetRandomJokeAsync();

                var infoBioUrl = _configuration["Infobio:ApiUrl"];
                var inforBioApiKey = _configuration["Infobio:ApiKey"];
                var inforBioApiRequestPath = _configuration["Infobio:ApiRequestPath"];
                var inforBioRecipient = _configuration["Infobio:Recipient"];
                var inforBioSender = _configuration["Infobio:Sender"];

                var options = new RestClientOptions(baseUrl: infoBioUrl!);
                var client = new RestClient(options);
                var request = new RestRequest(inforBioApiRequestPath, Method.Post);
                request.AddHeader("Authorization", inforBioApiKey!);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                var body = @"{""messages"":[{""destinations"":[{""to"":""recipient""}],""from"":""sender"",""text"":""joke""}]}";
                body = body.Replace("recipient", inforBioRecipient!)
                           .Replace("sender", inforBioSender!)
                           .Replace("joke", joke?.Joke);
                request.AddStringBody(body, DataFormat.Json);

                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("An error occurred while fetching the joke.");
            }
            finally
            {
                _logger.LogInformation("SendJokeToRecipientSmsAsync End: Time {time}", DateTime.UtcNow);
            }
        }
    }
}
