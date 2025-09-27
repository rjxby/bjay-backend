using System.Text.Json.Serialization;

namespace Bjay.Api.Services.Contracts.Entities.Activities;

public class DiaperMetaEntity
{
    [JsonPropertyName("type")]
    public required DiaperType Type { get; init; }
}
