namespace Bjay.Api.Services.Contracts.Entities.Activities;

public record ActivityPaginationEntity(ActivityType? Type, int Page, int Limit) : PaginationEntity(Page, Limit)
{
}
