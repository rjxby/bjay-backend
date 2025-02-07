using AutoMapper;
using FluentValidation;

using Bjay.Api.Host.Requests;
using Bjay.Api.Services.Contracts;
using Bjay.Api.Services.Contracts.Entities;

namespace Bjay.Api.Host;

public static class ActivitiesEndpoint
{
    public static void MapActivitiesEndpoint(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/activities")
            .WithTags("activities");

        group.MapGet("/", async (IMapper mapper, IActivityService service, [AsParameters] PaginationRequest request) =>
        {
            var paginationEntity = new PaginationEntity(request.Page, request.Limit);
            var result = await service.GetListAsync(paginationEntity);
            return mapper.Map<PaginationResponse<ActivityResponse>>(result);
        });

        group.MapGet("{id}", async (IMapper mapper, IActivityService service, Guid id) =>
        {
            var result = await service.GetAsync(id);
            return mapper.Map<ActivityResponse>(result);
        });

        group.MapPost("/", async (IValidator<ModifyActivityRequest> validator, IMapper mapper, IActivityService service, ModifyActivityRequest request) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var modelToCreate = mapper.Map<ActivityEntity>(request);
            modelToCreate.Id = Guid.NewGuid();

            var result = await service.CreateAsync(modelToCreate);
            return Results.Json(mapper.Map<ActivityResponse>(result), statusCode: 201);
        });

        group.MapPut("{id}", async (IMapper mapper, IActivityService service, Guid id, ModifyActivityRequest request) =>
        {
            var modelToUpdate = mapper.Map<ActivityEntity>(request);
            modelToUpdate.Id = id;

            var result = await service.UpdateAsync(id, modelToUpdate);
            return mapper.Map<ActivityResponse>(result);
        });

        group.MapDelete("{id}", async (IMapper mapper, IActivityService service, Guid id) => await service.DeleteAsync(id));
    }
}
