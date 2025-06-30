using System.Text.Json.Serialization;

namespace EntityFramework.Models;

internal class Person
{
    [JsonPropertyName(nameof(DateTime))]
    public string DateTime { get; set; }

    [JsonPropertyName(nameof(Name))]
    public string Name { get; set; }

    [JsonPropertyName(nameof(Gender))]
    public Gender Gender { get; set; }
}
