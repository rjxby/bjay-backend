using AutoMapper;

using Bjay.Api.Host.Requests;
using Bjay.Api.Services.Contracts.Entities;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Host;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AccountEntity, AccountResponse>();

        CreateMap<ActivityEntity, ActivityResponse>();

        CreateMap<ModifyActivityRequest, ActivityEntity>()
            .ForMember(x => x.Id, opt => opt.Ignore());

        CreateMap(typeof(PaginationResultEntity<>), typeof(PaginationResponse<>));
    }
}
