using Bjay.Api.Repositories.Contracts;
using Bjay.Api.Repositories.Contracts.Records;

namespace Bjay.Api.Repositories.Implementation;

public class AccountsRepository(DatabaseContext context) : BaseRepository(context), IAccountsRepository
{
    public async Task<AccountRecord> CreateAsync(AccountRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);

        var result = await CommitAsync(async () =>
        {
            var createdRecordEntry = await _context.Accounts.AddAsync(record);
            return createdRecordEntry.Entity;
        });

        return result;
    }

    public async Task<AccountRecord?> GetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Account ID is not valid.");
        }

        var result = await _context.Accounts.FindAsync(id);
        return result;
    }
}
