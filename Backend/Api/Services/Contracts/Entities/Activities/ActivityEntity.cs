namespace Bjay.Api.Services.Contracts.Entities.Activities;

public class ActivityEntity
{
    public required Guid Id { get; set; }
    public required Guid AccountId { get; init; }
    public required ActivityType Type { get; init; }
    public required DateTime StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public double? Amount { get; init; }
    public object? Meta { get; init; }
}
