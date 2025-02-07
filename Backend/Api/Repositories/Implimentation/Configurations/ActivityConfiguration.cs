using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Bjay.Api.Repositories.Contracts.Records;
using Microsoft.EntityFrameworkCore;

namespace Bjay.Api.Repositories.Implementation.Configurations;

public class ActivityConfiguration : BaseConfiguration<ActivityRecord>
{
       public new void Configure(EntityTypeBuilder<ActivityRecord> builder)
       {
              base.Configure(builder);

              builder.Property(x => x.AccountId)
                     .IsRequired();

              builder.HasOne(x => x.Account)
                     .WithMany()
                     .HasForeignKey(x => x.AccountId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.Property(x => x.Type)
                     .IsRequired();

              builder.Property(x => x.StartTime)
                    .HasUtcConversion()
                    .IsRequired();

              builder.Property(x => x.EndTime)
                     .HasUtcConversion();
              builder.Property(x => x.Amount);

              builder.Property(x => x.Meta);
       }
}
