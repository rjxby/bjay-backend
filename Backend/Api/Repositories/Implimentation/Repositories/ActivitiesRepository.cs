using Microsoft.EntityFrameworkCore;

using Bjay.Api.Repositories.Contracts;
using Bjay.Api.Repositories.Contracts.Records;

namespace Bjay.Api.Repositories.Implementation;

public class ActivitiesRepository(DatabaseContext context) : BaseRepository(context), IActivitiesRepository
{
    public async Task<(int size, IEnumerable<ActivityRecord> results)> GetListAsync(int? searchType, int page, int limit)
    {
        if (page < 1 || limit < 1)
        {
            throw new ArgumentException("Page and Limit must be positive integers.");
        }

        IQueryable<ActivityRecord> query = _context.Activities.OrderByDescending(p => p.StartTime);
        if (searchType.HasValue)
        {
            if (searchType < 1)
            {
                throw new ArgumentException("Search Type must be a positive integer.");
            }

            query = _context.Activities.Where(a => a.Type == searchType);
        }

        var size = await query.CountAsync();

        var offset = (page - 1) * limit;
        var results = await query
            .Skip(offset)
            .Take(limit)
            .ToListAsync();

        return (size, results);
    }

    public async Task<ActivityRecord> CreateAsync(ActivityRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);

        var result = await CommitAsync(async () =>
        {
            var createdRecordEntry = await _context.Activities.AddAsync(record);
            return createdRecordEntry.Entity;
        });

        return result;
    }

    public async Task<ActivityRecord?> GetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Activity ID is not valid.");
        }

        var result = await _context.Activities.FindAsync(id);
        return result;
    }

    public async Task<ActivityRecord> UpdateAsync(ActivityRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);

        var existingRecord = await GetAsync(record.Id);
        if (existingRecord == null)
        {
            throw new ArgumentNullException($"Activity record with ID {record.Id} not found.");
        }

        var result = await CommitAsync(() =>
        {
            _context.Entry(existingRecord).CurrentValues.SetValues(record);

            return Task.FromResult(existingRecord);
        });

        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Activity ID is not valid.");
        }

        var existingRecord = await GetAsync(id);
        if (existingRecord == null)
        {
            return true;
        }

        await CommitAsync(() =>
        {
            existingRecord.IsDeleted = true;
            return Task.FromResult(existingRecord);
        });

        return true;
    }
}
