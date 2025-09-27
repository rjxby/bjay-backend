using Bjay.Api.Services.Contracts.Entities;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Services.Contracts;

public interface IActivityService
{
    Task<PaginationResultEntity<ActivityEntity>> GetListAsync(ActivityPaginationEntity pagination);

    Task<ActivityEntity> GetAsync(Guid id);

    Task<ActivityEntity> CreateAsync(ActivityEntity entity);

    Task<ActivityEntity> UpdateAsync(Guid id, ActivityEntity entity);

    Task<bool> DeleteAsync(Guid id);
}
