namespace Bjay.Api.Repositories.Contracts.Records;

public class ActivityRecord : BaseRecord
{
    public required Guid AccountId { get; init; }
    public required AccountRecord Account { get; init; }

    public required int Type { get; init; }
    public required DateTime StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public string? Amount { get; init; }
    public string? Meta { get; init; }
}
