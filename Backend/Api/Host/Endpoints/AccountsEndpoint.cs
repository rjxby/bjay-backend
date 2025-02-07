using AutoMapper;

using Bjay.Api.Services.Contracts;
using Bjay.Api.Services.Contracts.Entities;

namespace Bjay.Api.Host;

public static class AccountsEndpoint
{
    public static void MapAccountsEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/accounts")
            .WithTags("accounts");

        group.MapGet("{id}", async (IMapper mapper, IAccountService service, Guid id) =>
        {
            var result = await service.GetAsync(id);
            return mapper.Map<AccountResponse>(result);
        });

        group.MapPost("/", async (IMapper mapper, IAccountService service) =>
        {
            var modelToCreate = new AccountEntity(Guid.NewGuid());
            var result = await service.CreateAsync(modelToCreate);
            return mapper.Map<AccountResponse>(result);
        });
    }
}
