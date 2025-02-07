using Microsoft.EntityFrameworkCore;

using Bjay.Api.Repositories.Contracts.Records;
using Bjay.Api.Repositories.Implementation.Configurations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bjay.Api.Repositories.Implementation;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<AccountRecord> Accounts { get; set; } = null!;
    public DbSet<ActivityRecord> Activities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion<UtcDateTimeConvertor>();

        configurationBuilder
            .Properties<DateTime?>()
            .HaveConversion<NullableUtcDateTimeConvertor>();

        base.ConfigureConventions(configurationBuilder);
    }
}
