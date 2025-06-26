using CustomCLI.Models;

namespace CustomCLI.Services
{
    /// <summary>
    /// Interface for a service that fetches jokes.
    /// </summary>
    internal interface IJokeService
    {
        /// <summary>
        /// Fetches a random joke from the joke API.
        /// </summary>
        /// <returns></returns>
        public Task<JokeResponse> GetRandomJokeAsync();
    }
}
