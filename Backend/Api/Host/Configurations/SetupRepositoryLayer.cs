using Microsoft.EntityFrameworkCore;

using Bjay.Api.Repositories.Contracts;
using Bjay.Api.Repositories.Implementation;

namespace Bjay.Api.Host;

public static class SetupRepositoryLayer
{
    public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<DatabaseContext>(o =>
        {
            o.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddTransient<IAccountsRepository, AccountsRepository>();
        services.AddTransient<IActivitiesRepository, ActivitiesRepository>();

        return services;
    }
}
