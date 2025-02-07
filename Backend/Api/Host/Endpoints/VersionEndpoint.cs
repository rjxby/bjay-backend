namespace Bjay.Api.Host;

public static class VersionEndpoint
{
    public static void MapVersionEndpoint(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/version")
            .WithTags("version");

        group.MapGet("/", () => new { version = VersionInfo.GetVersion() });
    }
}
