using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

using Bjay.Api.Host.Endpoints.Validators;
using Bjay.Api.Host.Requests;

namespace Bjay.Api.Host;

public static class SetupPresentationLayer
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddSwagger();

        services.AddExceptionHandler<ExceptionHandler>();
        services.AddProblemDetails();

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IValidator<ModifyActivityRequest>, ModifyActivityRequestValidator>();

        services.Configure<JsonOptions>(options =>
                 options.SerializerOptions.DefaultIgnoreCondition
           = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull);

        return services;
    }
}
