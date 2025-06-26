using System.Text.Json.Serialization;

namespace CustomCLI.Models
{
    internal class JokeResponse
    {
        [JsonPropertyName("lang")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName(nameof(Category))]  
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName(nameof(Joke))]
        public string Joke { get; set; } = string.Empty;

        [JsonPropertyName(nameof(Id))]
        public int Id { get; set; }
    }
}
