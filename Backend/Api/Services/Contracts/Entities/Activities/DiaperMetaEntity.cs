using System.Text.Json.Serialization;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Services.Contracts.Entities;

public class DiaperMetaEntity
{
    [JsonPropertyName("type")]
    public required DiaperType Type { get; init; }
}
