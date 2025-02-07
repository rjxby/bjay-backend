using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bjay.Api.Repositories.Implementation.Configurations;

public static class ModelBuilderExtensions
{
    public static PropertyBuilder<DateTime> HasUtcConversion(this PropertyBuilder<DateTime> builder)
    {
        return builder.HasConversion(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        );
    }

    public static PropertyBuilder<DateTime?> HasUtcConversion(this PropertyBuilder<DateTime?> builder)
    {
        return builder.HasConversion(
            v => v,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : null
        );
    }
}