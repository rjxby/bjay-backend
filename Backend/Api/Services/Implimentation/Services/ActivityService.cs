using AutoMapper;

using Bjay.Api.Repositories.Contracts;
using Bjay.Api.Repositories.Contracts.Records;
using Bjay.Api.Services.Contracts;
using Bjay.Api.Services.Contracts.Entities;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Services.Implementation.Services;

public class ActivityService(IMapper mapper, IActivitiesRepository activitiesRepository) : IActivityService
{
    public async Task<PaginationResultEntity<ActivityEntity>> GetListAsync(ActivityPaginationEntity pagination)
    {
        var searchType = (int?)pagination.Type;
        var (size, foundRecords) = await activitiesRepository.GetListAsync(searchType, pagination.Page, pagination.Limit);

        var resultRecords = mapper.Map<IEnumerable<ActivityEntity>>(foundRecords);

        var result = new PaginationResultEntity<ActivityEntity>(pagination.Page, pagination.Limit, size, resultRecords);
        return result;
    }

    public async Task<ActivityEntity> GetAsync(Guid id)
    {
        var record = await GetByIdAsync(id);
        return mapper.Map<ActivityEntity>(record);
    }

    public async Task<ActivityEntity> CreateAsync(ActivityEntity entity)
    {
        var recordToCreate = mapper.Map<ActivityRecord>(entity);
        var createdRecord = await activitiesRepository.CreateAsync(recordToCreate);
        return mapper.Map<ActivityEntity>(createdRecord);
    }

    public async Task<ActivityEntity> UpdateAsync(Guid id, ActivityEntity entity)
    {
        var recordToUpdate = await GetByIdAsync(id);

        mapper.Map(entity, recordToUpdate);

        var updatedRecord = await activitiesRepository.UpdateAsync(recordToUpdate);
        return mapper.Map<ActivityEntity>(updatedRecord);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await activitiesRepository.DeleteAsync(id);
    }

    private async Task<ActivityRecord> GetByIdAsync(Guid id)
    {
        var record = await activitiesRepository.GetAsync(id);
        if (record == null)
        {
            throw new KeyNotFoundException($"Activity with ID {id} not found.");
        }

        return record;
    }
}
