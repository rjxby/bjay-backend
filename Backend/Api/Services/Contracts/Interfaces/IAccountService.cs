using Bjay.Api.Services.Contracts.Entities;

namespace Bjay.Api.Services.Contracts;

public interface IAccountService
{
    Task<AccountEntity> GetAsync(Guid id);

    Task<AccountEntity> CreateAsync(AccountEntity entity);

    Task<AccountEntity> DeleteAsync(Guid id);
}
