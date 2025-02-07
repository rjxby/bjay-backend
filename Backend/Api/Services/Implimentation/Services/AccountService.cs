using AutoMapper;

using Bjay.Api.Repositories.Contracts;
using Bjay.Api.Repositories.Contracts.Records;
using Bjay.Api.Services.Contracts;
using Bjay.Api.Services.Contracts.Entities;

namespace Bjay.Api.Services.Implementation.Services;

public class AccountService(IMapper mapper, IAccountsRepository accountsRepository) : IAccountService
{
    public async Task<AccountEntity> GetAsync(Guid id)
    {
        var record = await GetByIdAsync(id);
        return mapper.Map<AccountEntity>(record);
    }

    public async Task<AccountEntity> CreateAsync(AccountEntity entity)
    {
        var recordToCreate = mapper.Map<AccountRecord>(entity);
        var createdRecord = await accountsRepository.CreateAsync(recordToCreate);
        return mapper.Map<AccountEntity>(createdRecord);
    }

    public Task<AccountEntity> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    private async Task<AccountRecord> GetByIdAsync(Guid id)
    {
        var record = await accountsRepository.GetAsync(id);
        if (record == null)
        {
            throw new KeyNotFoundException($"Account with ID {id} not found.");
        }

        return record;
    }
}
