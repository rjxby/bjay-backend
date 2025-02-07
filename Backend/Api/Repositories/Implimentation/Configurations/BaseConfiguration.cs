using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Bjay.Api.Repositories.Contracts.Records;

namespace Bjay.Api.Repositories.Implementation.Configurations;

public abstract class BaseConfiguration<TConfiguration> : IEntityTypeConfiguration<TConfiguration> where TConfiguration : BaseRecord
{
    public void Configure(EntityTypeBuilder<TConfiguration> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
