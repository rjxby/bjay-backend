using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bjay.Api.Repositories.Implementation;

public class NullableUtcDateTimeConvertor : ValueConverter<DateTime?, DateTime?>
{
    public NullableUtcDateTimeConvertor()
        : base(
            v => v,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)
    {
    }
}
