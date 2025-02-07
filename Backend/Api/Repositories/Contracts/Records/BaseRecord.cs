namespace Bjay.Api.Repositories.Contracts.Records;

public abstract class BaseRecord
{
    public required Guid Id { get; set; }
    public required bool IsDeleted { get; set; }
}
