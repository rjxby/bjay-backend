using System.Text.Json;
using FluentValidation;

using Bjay.Api.Host.Endpoints.Requests.Activity;
using Bjay.Api.Host.Requests;
using Bjay.Api.Services.Contracts.Entities.Activities;

namespace Bjay.Api.Host.Endpoints.Validators;

public class ModifyActivityRequestValidator : AbstractValidator<ModifyActivityRequest>
{
    public ModifyActivityRequestValidator()
    {
        RuleFor(x => x.AccountId).NotEmpty().WithMessage("AccountId is required.");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
        RuleFor(x => x.StartTime).NotEmpty().WithMessage("StartTime is required.");

        When(x => x.Type == ActivityType.Diaper, () =>
        {
            RuleFor(x => x.Meta)
                .NotNull().WithMessage($"Meta is required for Type '{nameof(ActivityType.Diaper)}'.")
                .Must(meta =>
                {
                    var metaAsStringJson = JsonSerializer.Serialize(meta);
                    DiaperMetaRequest? metaAsDiaperMeta = null;
                    try
                    {
                        metaAsDiaperMeta = JsonSerializer.Deserialize<DiaperMetaRequest?>(metaAsStringJson);
                    }
                    catch
                    {
                    }

                    return metaAsDiaperMeta is not null;
                }).WithMessage($"Invalid Meta type for Type '{nameof(ActivityType.Diaper)}'.");
        });

        When(x => x.Type != ActivityType.Diaper, () =>
        {
            RuleFor(x => x.Meta)
                .Null().WithMessage("Meta is not known for this type.");
        });
    }
}
