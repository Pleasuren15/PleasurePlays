using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityFramework.Models;

public class Person
{
    [Key]
    [JsonPropertyName(nameof(PersonId))]
    public Guid PersonId { get; set; } = Guid.NewGuid();

    [JsonPropertyName(nameof(DateOfBirth))]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName(nameof(Name))]
    public string Name { get; set; }

    [JsonPropertyName(nameof(Gender))]
    public Gender Gender { get; set; }
}
