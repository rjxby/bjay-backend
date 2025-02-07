using System.Text.Json;
using AutoMapper;

using Bjay.Api.Repositories.Contracts.Records;
using Bjay.Api.Services.Contracts.Entities;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Services.Implementation;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AccountEntity, AccountRecord>()
            .ReverseMap();

        CreateMap<ActivityEntity, ActivityRecord>()
            .ForMember(x => x.Meta, opt => opt.MapFrom((src, dst) => src.Meta is not null ? JsonSerializer.Serialize(src.Meta) : null));

        CreateMap<ActivityRecord, ActivityEntity>()
            .ForMember(x => x.Meta, opt => opt.MapFrom((src, dst) =>
            {
                if (string.IsNullOrEmpty(src.Meta))
                {
                    return null;
                }

                if (src.Type == (int)ActivityType.Diaper)
                {
                    return JsonSerializer.Deserialize<DiaperMetaEntity>(src.Meta);
                }

                return JsonSerializer.Deserialize<object>(src.Meta);
            }));
    }
}
