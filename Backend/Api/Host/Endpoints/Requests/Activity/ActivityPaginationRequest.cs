using Bjay.Api.Services.Contracts.Entities.Activities;
using System.ComponentModel.DataAnnotations;

namespace Bjay.Api.Host.Requests.Activity;

public record ActivityPaginationRequest : PaginationRequest
{
    [EnumDataType(typeof(ActivityType), ErrorMessage = "Invalid activity type.")]
    public ActivityType? Type { get; init; }
}
