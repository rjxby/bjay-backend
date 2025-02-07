using Bjay.Api.Services.Contracts;
using Bjay.Api.Services.Implementation.Services;

namespace Bjay.Api.Host;

public static class SetupServiceLayer
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Services.Implementation.MappingProfile));

        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IActivityService, ActivityService>();

        return services;
    }
}
