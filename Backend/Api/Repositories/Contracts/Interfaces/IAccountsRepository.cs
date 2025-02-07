using Bjay.Api.Repositories.Contracts.Records;

namespace Bjay.Api.Repositories.Contracts;

public interface IAccountsRepository
{
    Task<AccountRecord?> GetAsync(Guid id);

    Task<AccountRecord> CreateAsync(AccountRecord record);
}
