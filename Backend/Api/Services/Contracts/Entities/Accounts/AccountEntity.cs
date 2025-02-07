using System.Diagnostics.CodeAnalysis;

namespace Bjay.Api.Services.Contracts.Entities;

[method: SetsRequiredMembers]
public class AccountEntity(Guid id)
{
    public required Guid Id { get; set; } = id;
}
