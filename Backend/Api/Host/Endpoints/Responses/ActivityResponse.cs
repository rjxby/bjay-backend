using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Host;

public record ActivityResponse(Guid Id, Guid AccountId, ActivityType Type, DateTime StartTime, DateTime? EndTime, double? Amount, object? Meta);
