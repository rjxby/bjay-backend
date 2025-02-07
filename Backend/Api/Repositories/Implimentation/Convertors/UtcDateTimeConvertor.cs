using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bjay.Api.Repositories.Implementation;

public class UtcDateTimeConvertor : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeConvertor()
        : base(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}
