using Bjay.Api.Repositories.Contracts.Records;

namespace Bjay.Api.Repositories.Contracts;

public interface IActivitiesRepository
{
    Task<ActivityRecord?> GetAsync(Guid id);

    Task<ActivityRecord> CreateAsync(ActivityRecord record);

    Task<(int size, IEnumerable<ActivityRecord> results)> GetListAsync(int page, int limit);

    Task<ActivityRecord> UpdateAsync(ActivityRecord record);

    Task<bool> DeleteAsync(Guid id);
}
