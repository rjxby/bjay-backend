using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Host.Requests;

public record ModifyActivityRequest
{
    public Guid AccountId { get; init; }

    public ActivityType Type { get; init; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public double? Amount { get; set; }

    public object? Meta { get; set; }
}